using System;
using UnityEngine;

public class IsTransitioning : OnMessage<WorldSwapStarted, WorldSwapFinished>
{
    [SerializeField] private CurrentGameState gameState;

    protected override void Execute(WorldSwapStarted msg)
    {
        gameState.UpdateState(x => x.IsTransitioning = true);
    }

    protected override void Execute(WorldSwapFinished msg)
    {
        gameState.UpdateState(x => x.IsTransitioning = false);
    }
}