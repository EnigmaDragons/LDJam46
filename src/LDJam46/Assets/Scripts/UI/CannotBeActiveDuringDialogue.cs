
using UnityEngine;

public class CannotBeActiveDuringDialogue : MonoBehaviour
{
    [SerializeField] private CurrentGameState game;

    void OnEnable()
    {
        if (game.GameState.isInDialogue)
        {
            Debug.Log($"{gameObject.name} cannot be active while Player Is In Dialogue", gameObject);
            gameObject.SetActive(false);
        }
    }
}
