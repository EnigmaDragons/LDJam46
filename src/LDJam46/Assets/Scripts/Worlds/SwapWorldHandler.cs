using UnityEngine;

public class SwapWorldHandler : OnMessage<SwapWorld, ReadyForWorldSwapPeak, ReadyForWorldSwapFinished>
{
    [SerializeField] private GameObject realWorld;
    [SerializeField] private GameObject mindWorld;
    [SerializeField] private CurrentGameState game;

    private CurrentWorld _newWorld;
    
    protected override void Execute(SwapWorld msg)
    {
        _newWorld = game.CurrentWorld == CurrentWorld.Mind ? CurrentWorld.Real : CurrentWorld.Mind;
        Message.Publish(new WorldSwapStarted(_newWorld));
    }

    protected override void Execute(ReadyForWorldSwapPeak msg)
    {
        Activate(_newWorld);
        Message.Publish(new WorldSwapPeaked(_newWorld));
    }

    protected override void Execute(ReadyForWorldSwapFinished msg)
        => NotifyFinished(_newWorld);

    private void Activate(CurrentWorld targetWorld)
    {
        Debug.Log($"World Swap - Activating {targetWorld}");
        mindWorld.SetActive(targetWorld == CurrentWorld.Mind);
        realWorld.SetActive(targetWorld == CurrentWorld.Real);
    }

    private void NotifyFinished(CurrentWorld nowActive)
    {
        Debug.Log($"World Swap - Finished Swapping to {nowActive}");
        game.UpdateState(gs => gs.CurrentWorld = nowActive);
        Message.Publish(new WorldSwapFinished(nowActive));
    }
}
