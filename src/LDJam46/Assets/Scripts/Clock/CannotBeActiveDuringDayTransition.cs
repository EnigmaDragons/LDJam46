using UnityEngine;

public class CannotBeActiveDuringDayTransition : MonoBehaviour
{
    [SerializeField] private CurrentGameState game;

    void OnEnable()
    {
        if (game.GameState.IsTransitioningDays)
        {
            Debug.Log($"{gameObject.name} cannot be active while Day is Transitioning", gameObject);
            gameObject.SetActive(false);
        }
    }
}

