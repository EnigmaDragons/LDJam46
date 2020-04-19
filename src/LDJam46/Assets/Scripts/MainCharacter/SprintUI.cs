using System;
using UnityEngine;
using UnityEngine.UI;

public class SprintUI : OnMessage<SprintChanged>
{
    [SerializeField] private Slider sprintBar;
    [SerializeField] private float secondsToFade;
    [SerializeField] private Image background;
    [SerializeField] private Image fill;

    private bool _fading;

    protected override void Execute(SprintChanged msg)
    {
        _fading = msg.SprintPercentage == 1;
        sprintBar.value = msg.SprintPercentage;
    }

    private void Update()
    {
        if (!_fading)
        {
            fill.color = new Color(1, 1, 1, Math.Min(1, fill.color.a + Time.deltaTime / secondsToFade));
            background.color = new Color(1, 1, 1, Math.Min(1, fill.color.a + Time.deltaTime / secondsToFade) / 2);
        }
        else
        {
            fill.color = new Color(1, 1, 1, Math.Min(1, fill.color.a - Time.deltaTime / secondsToFade));
            background.color = new Color(1, 1, 1, Math.Min(1, fill.color.a - Time.deltaTime / secondsToFade) / 2);
        }
    }
}