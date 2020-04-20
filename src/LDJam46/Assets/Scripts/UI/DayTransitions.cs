using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayTransitions : OnMessage<StartNextDay>
{
    [SerializeField] private Image day;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private CurrentGameState gameState;
    [SerializeField] private float preFadeSeconds;
    [SerializeField] private float fadeInSeconds;
    [SerializeField] private Item[] startingItems;

    private float _prefadeRemaining;
    private bool _prefading;
    private bool _fadingIn;

    protected override void Execute(StartNextDay msg)
    {
        gameState.UpdateState(x =>
        {
            x.DayNumber++;
            x.HadPanicAttackToday = false;
        });
        text.text = $"DAY {gameState.GameState.DayNumber}";
        day.color = new Color(1, 1, 1, 1);
        text.color = new Color(1, 1, 1, 1);
        _prefading = true;
        _fadingIn = false;
        _prefadeRemaining = preFadeSeconds;
        startingItems.ForEach(i => Message.Publish(new GainItem(i)));
    }

    private void Update()
    {
        if (_prefading)
        {
            _prefadeRemaining -= Time.deltaTime;
            if (_prefadeRemaining <= 0)
            {
                _prefading = false;
                _fadingIn = true;
            }
        }
        else if (_fadingIn)
        {
            var a = Math.Max(0, day.color.a - Time.deltaTime / fadeInSeconds);
            day.color = new Color(1, 1, 1, a);
            text.color = new Color(1, 1, 1, a);
            if (a == 0)
            {
                _fadingIn = false;
                Message.Publish(new NewDayStarted());
            }
        }
    }
}