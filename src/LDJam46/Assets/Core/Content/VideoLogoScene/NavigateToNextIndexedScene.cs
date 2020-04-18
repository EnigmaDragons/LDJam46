using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class NavigateToNextIndexedScene : MonoBehaviour
{
    public void Go()
    {
        if (SceneManager.sceneCount > 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            Debug.Log("No Next Scene Found in Build");
    }
}
