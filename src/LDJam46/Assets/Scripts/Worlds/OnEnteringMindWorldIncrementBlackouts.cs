using UnityEngine;

public class OnEnteringMindWorldIncrementBlackouts : OnMessage<WorldSwapFinished>
{
    [SerializeField] private CurrentGameState game;
    
    protected override void Execute(WorldSwapFinished msg)
    {
        if (msg.World == CurrentWorld.Mind)
            game.UpdateState(gs => gs.NumBlackouts += 1);
    }
}
