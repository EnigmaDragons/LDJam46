using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadingScreen : MonoBehaviour
{
	[SerializeField] private Slider loadingSlider;
	[SerializeField] private GameObject forHiding;

	private void Start()
	{
		forHiding.SetActive(false);
	}

	public void LoadScene(string sceneName)
	{
		forHiding.SetActive(true);

		StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
	    yield return null; // this makes LoadingSceen appear right away

	    AsyncOperation sceneLoadOperation = SceneManager.LoadSceneAsync(sceneName);

	    while (!sceneLoadOperation.isDone)
	    {
		    loadingSlider.value = Mathf.Clamp01(sceneLoadOperation.progress / 0.9f);

		    yield return null;
	    }
    }
}
