using UnityEngine;

public class IncrementBlackoutCounter : OnMessage<WorldSwapPeaked>
{
    [SerializeField] private CurrentGameState gameState;

    protected override void Execute(WorldSwapPeaked msg)
    {
        if (msg.World == CurrentWorld.Mind)
            gameState.UpdateState(x => x.NumBlackouts++);
    }
}