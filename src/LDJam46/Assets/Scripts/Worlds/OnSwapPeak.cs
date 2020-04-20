using UnityEngine;

public class OnSwapPeak : OnMessage<WorldSwapPeaked>
{
    [SerializeField] private GameObject real;
    [SerializeField] private GameObject mind;
    
    protected override void Execute(WorldSwapPeaked msg)
    {
        real.SetActive(msg.World == CurrentWorld.Real);
        mind.SetActive(msg.World == CurrentWorld.Mind);
    }
}
