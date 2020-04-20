using UnityEngine;

public class OnComfortConsumed : OnMessage<ComfortConsumed>
{
    [SerializeField] private CurrentGameState gameState;

    protected override void Execute(ComfortConsumed msg)
    {
        gameState.UpdateState(x => x.ComfortsConsumedLastBlackoutToday.Add(msg.Comfort));
    }
}