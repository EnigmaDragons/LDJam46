using UnityEngine;

public class SwapWorldHandler : OnMessage<SwapWorld>
{
    [SerializeField] private GameObject realWorld;
    [SerializeField] private GameObject mindWorld;
    [SerializeField] private CurrentGameState game;
    [SerializeField] private WorldSwapVisualTransition transition;
    
    protected override void Execute(SwapWorld msg)
    {
        var newWorld = game.CurrentWorld == CurrentWorld.Mind ? CurrentWorld.Real : CurrentWorld.Mind;
        Message.Publish(new WorldSwapStarted());
        transition.ShowTransition(
            () => Activate(newWorld),
            () => NotifyFinished(newWorld)); 
    }        
    
    private void Activate(CurrentWorld targetWorld)
    {
        mindWorld.SetActive(targetWorld == CurrentWorld.Mind);
        realWorld.SetActive(targetWorld == CurrentWorld.Real);
    }

    private void NotifyFinished(CurrentWorld nowActive)
    {
        game.UpdateState(gs => gs.CurrentWorld = nowActive);
        Message.Publish(new WorldSwapFinished());
    }
}
