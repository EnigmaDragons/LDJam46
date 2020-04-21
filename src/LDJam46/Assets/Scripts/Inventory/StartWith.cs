using UnityEngine;

public class StartWith : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private CurrentGameState gameState;

    public void Start() => Message.Publish(new GainItem(item));
}