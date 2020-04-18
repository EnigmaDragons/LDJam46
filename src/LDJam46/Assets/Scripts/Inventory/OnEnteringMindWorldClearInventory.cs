
using UnityEngine;

public class OnEnteringMindWorldClearInventory : OnMessage<WorldSwapStarted>
{
    [SerializeField] private CurrentGameState game;
    
    protected override void Execute(WorldSwapStarted msg)
    {
        if (msg.NewWorld == CurrentWorld.Mind)
            game.UpdateState(gs => gs.Items.Clear());
    }
}
