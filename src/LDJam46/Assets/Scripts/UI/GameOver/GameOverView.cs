using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private Navigator navigator;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitToMenuButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(() => navigator.NavigateToGameScene());
        quitToMenuButton.onClick.AddListener(() => navigator.NavigateToMainMenu());
    }
}
