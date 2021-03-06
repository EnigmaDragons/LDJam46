﻿
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
        var usedItems = new HashSet<Item>();
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
                usedItems.Add(item);
            }
        }
        foreach (var item in usedItems)
            Message.Publish(new UseItem(item));
        if (states.All(x => !x.IsActive))
            Message.Publish(new SwapWorld());
    }
}
