using UnityEngine;

public class SwapWorldHandler : OnMessage<SwapWorld, ReadyForWorldSwapPeak, ReadyForWorldSwapFinished, GotoWorldInstantly>
{
    [SerializeField] private GameObject realWorld;
    [SerializeField] private GameObject mindWorld;
    [SerializeField] private CurrentGameState game;

    private CurrentWorld _newWorld;
    private bool _isSwapping;
    
    protected override void Execute(SwapWorld msg)
    {
        Debug.Log("World Swap - Received Swap World Message");
        if (_isSwapping)
        {
            Debug.LogError("Not allowed to Swap Worlds mid-swap");
            return;
        }

        _isSwapping = true;
        _newWorld = game.CurrentWorld == CurrentWorld.Mind ? CurrentWorld.Real : CurrentWorld.Mind;
        Message.Publish(new WorldSwapStarted(_newWorld, false));
    }

    protected override void Execute(ReadyForWorldSwapPeak msg)
    {
        Activate(_newWorld);
        Message.Publish(new WorldSwapPeaked(_newWorld));
    }

    protected override void Execute(ReadyForWorldSwapFinished msg)
        => NotifyFinished(_newWorld);

    protected override void Execute(GotoWorldInstantly msg)
    {        
        Debug.Log("World Swap - Received Go To World Instantly");
        if (_isSwapping)
        {
            Debug.LogError("Not allowed to Swap Worlds mid-swap");
            return;
        }
        _newWorld = game.CurrentWorld == CurrentWorld.Mind ? CurrentWorld.Real : CurrentWorld.Mind;
        Message.Publish(new WorldSwapStarted(_newWorld, true));
    }

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
        _isSwapping = false;
        Message.Publish(new WorldSwapFinished(nowActive));
    }
}
