using System.Linq;
using UnityEngine;

public class OnEnteringMindWorldClearInventory : OnMessage<WorldSwapStarted>
{
    [SerializeField] private CurrentGameState game;
    [SerializeField] private string[] persistentItems = new string[1] { "Pills" };
    
    protected override void Execute(WorldSwapStarted msg)
    {
        if (msg.NewWorld == CurrentWorld.Mind)
            game.UpdateState(gs => gs.Items = gs.Items.Where(i => persistentItems.Contains(i.Name)).ToList());
    }
}
