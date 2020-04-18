using UnityEngine;
using UnityEngine.UI;

public class UseDialoguePanelForWorld : MonoBehaviour
{
    [SerializeField] private CurrentGameState game;
    [SerializeField] private Image image;
    [SerializeField] private Sprite realWorldPanel;
    [SerializeField] private Sprite mindWorldPanel;

    private void OnEnable() => image.sprite = game.CurrentWorld == CurrentWorld.Real ? realWorldPanel : mindWorldPanel;
}
