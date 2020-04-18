using UnityEngine;

public class SwapWorldHandler : OnMessage<SwapWorld>
{
    [SerializeField] private GameObject realWorld;
    [SerializeField] private GameObject mindWorld;
    [SerializeField] private CurrentGameState game;
    
    protected override void Execute(SwapWorld msg)
    {
        if (game.CurrentWorld == CurrentWorld.Real)
        {
            Message.Publish(new WorldSwapStarted());
            realWorld.SetActive(false);
            mindWorld.SetActive(true);
            game.UpdateState(gs => gs.CurrentWorld = CurrentWorld.Mind);
            Message.Publish(new WorldSwapFinished());
        }
        else
        {
            Message.Publish(new WorldSwapStarted());
            mindWorld.SetActive(false);
            realWorld.SetActive(true);
            game.UpdateState(gs => gs.CurrentWorld = CurrentWorld.Real);
            Message.Publish(new WorldSwapFinished());
        }
    }
}
