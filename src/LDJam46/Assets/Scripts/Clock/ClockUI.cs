using System;
using TMPro;
using UnityEngine;

public class ClockUI : OnMessage<PassTime>
{
    [SerializeField] private TextMeshProUGUI clock;

    private int _minutes = 0;

    protected override void Execute(PassTime msg)
    {
        _minutes += msg.Minutes;
        SetTime();
    }

    private void Start()
    {
        SetTime();
    }

    private void SetTime()
    {
        clock.text = $"{Math.Floor((decimal)_minutes / 60):00}:{(_minutes % 60):00}";
    }
}