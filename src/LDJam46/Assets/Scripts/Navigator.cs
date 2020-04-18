using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "OnlyOnce/Navigator")]
public class Navigator : ScriptableObject
{
    public void NavigateToMainMenu() => NavigateTo("MainMenu");
    public void NavigateToGameScene() => NavigateTo("GameScene");
    public void NavigateToGameOver() => NavigateTo("GameOver");
    public void NavigateToVictory() => NavigateTo("VictoryScene");

    private void NavigateTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
	    UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
