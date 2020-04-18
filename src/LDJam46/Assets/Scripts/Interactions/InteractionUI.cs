using System;
using TMPro;
using UnityEngine;

public class InteractionUI : OnMessage<SetAvailableInteraction, ClearAvailableInteraction>
{
    [SerializeField] private TextMeshProUGUI text;

    private bool _interactionAvailable;
    private Action _action = () => {};

    protected override void Execute(SetAvailableInteraction msg)
    {
        _action = msg.OnInteract;
        text.text = $"Click or press enter to interact with \"{msg.Name}\"";
        text.gameObject.SetActive(true);
        _interactionAvailable = true;
    }

    protected override void Execute(ClearAvailableInteraction msg)
    {
        _interactionAvailable = false;
        text.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_interactionAvailable && Input.GetButtonDown("Continue"))
        {
            _action();
            Execute(new ClearAvailableInteraction());
        }
    }
}