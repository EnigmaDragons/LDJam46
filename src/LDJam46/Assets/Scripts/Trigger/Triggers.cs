using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Triggers : OnMessage<ActivateTrigger>
{
    [SerializeField] private List<Trigger> triggers;

    protected override void Execute(ActivateTrigger msg)
    {
        var trigger = triggers.FirstOrDefault(x => x.Name == msg.Trigger);
        trigger?.Obj.SetActive(true);
    }
}