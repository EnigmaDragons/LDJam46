using UnityEngine;
using UnityEngine.UI;

public class SwapImageOnWorldSwap : OnMessage<WorldSwapPeaked>
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite real;
    [SerializeField] private Sprite mind;

    protected override void Execute(WorldSwapPeaked msg)
    {
        image.sprite = msg.World == CurrentWorld.Real ? real : mind;
    }
}