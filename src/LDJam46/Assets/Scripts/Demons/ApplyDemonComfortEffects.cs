
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Demons;
using UnityEngine;

public class ApplyDemonComfortEffects : OnMessage<ComfortConsumed>
{
    [SerializeField] private List<DemonState> states = new List<DemonState>();
    [SerializeField] private CurrentGameState gameState;
    
    protected override void Execute(ComfortConsumed msg)
    {
        foreach (var state in states)
        {
            var item = gameState.GameState.Items.FirstOrDefault(i => i.ComfortBonuses.Any(x => x.Comfort == msg.Comfort));
            if (item == null)
            {
                state.Setback(msg.Comfort.ComfortLevels.Any(x => x.Demon == state.Name)
                    ? msg.Comfort.ComfortLevels.First(x => x.Demon == state.Name).Percentage
                    : msg.Comfort.DefaultPercentage);
            }
            else
            {
                var itemComfort = item.ComfortBonuses.First(x => x.Comfort == msg.Comfort);
                state.Setback(itemComfort.PerDemon.Any(x => x.Demon == state.Name)
                    ? itemComfort.PerDemon.First(x => x.Demon == state.Name).Percentage
                    : itemComfort.DefaultPercentage);
                Message.Publish(new UseItem(item));
            }
        }
    }
}
