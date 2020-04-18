using UnityEngine;

public class BodySwap : OnMessage<WorldSwapStarted, WorldSwapPeaked>
{
    [SerializeField] private GameObject realBody;
    [SerializeField] private GameObject mindBody;

    private CurrentWorld _world;

    protected override void Execute(WorldSwapStarted msg)
    {
        _world = msg.NewWorld;
    }

    protected override void Execute(WorldSwapPeaked msg)
    {
        if (_world == CurrentWorld.Real)
        {
            mindBody.SetActive(false);
            realBody.SetActive(true);
        }
        else
        {
            realBody.SetActive(false);
            mindBody.SetActive(true);
        }
    }
}