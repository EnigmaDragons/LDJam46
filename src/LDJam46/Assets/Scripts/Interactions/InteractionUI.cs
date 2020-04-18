using System;
using TMPro;
using UnityEngine;

public class InteractionUI : OnMessage<SetAvailableInteraction>
{
    [SerializeField] private TextMeshProUGUI text;

    private Action _action = () => {};

    protected override void Execute(SetAvailableInteraction msg)
    {
        _action = msg.OnInteract;
        text.text = $"Click or press enter to interact with \"{msg.Name}\"";
    }

    private void Update()
    {
        if (Input.GetButtonDown("Continue"))
            _action();
    }
}