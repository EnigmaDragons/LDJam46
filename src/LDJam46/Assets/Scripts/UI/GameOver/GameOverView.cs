using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private CurrentGameState game;
    [SerializeField] private Button nextDayButton;

    private void Awake() => nextDayButton.onClick.AddListener(GoToNextDay);

    public void GoToNextDay()
    {
        Debug.Log($"GameOverView - User Confirmed Go To Next Day", gameObject);
        gameObject.SetActive(false);
        Message.Publish(new StartNextDay());
    }

    private void OnEnable() => game.UpdateState(g => g.IsShowingGameOverScreen = true);
    private void OnDisable() => game.UpdateState(g => g.IsShowingGameOverScreen = false);
}
