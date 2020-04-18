
using System.Collections.Generic;
using UnityEngine;

public class ApplyDemonComfortEffects : OnMessage<ComfortConsumed>
{
    [SerializeField] private List<DemonState> states = new List<DemonState>();
    
    protected override void Execute(ComfortConsumed msg)
    {
        states.ForEach(d => d.Setback(msg.Comfort.BaseSetBackAmount));
    }
}
