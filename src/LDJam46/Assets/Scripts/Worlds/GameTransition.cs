using UnityEngine;

[CreateAssetMenu(menuName = "OnlyOnce/GameTransition")]
public class GameTransition : ScriptableObject
{
    public void SwapWorlds() => Message.Publish(new SwapWorld());
}
