using UnityEngine;

public class Pills : MonoBehaviour
{
    [SerializeField] private Comfort pillsComfort;
    [SerializeField] private Item pillsItem;
    [SerializeField] private CurrentGameState gameState;

    private void Update()
    {
        if (Input.GetButtonDown("Pills") && gameState.GameState.Items.Contains(pillsItem))
        {
            if (gameState.CurrentWorld == CurrentWorld.Real)
            {
            }
            else
            {
                Message.Publish(new UseItem(pillsItem));
                Message.Publish(new ComfortConsumed(pillsComfort));
            }
        }
    }
}
