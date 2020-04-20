using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
	[SerializeField] private Slider loadingSlider;
	[SerializeField] private GameObject forHiding;
	[SerializeField] private Animator backgroundAnimator;

	private void Start()
	{
		forHiding.SetActive(false);
	}

	public void InitiLoad()
	{
		forHiding.SetActive(true);
		backgroundAnimator.SetTrigger("Start");
	}

	public void LoadScene(string sceneName)
	{
		StartCoroutine(LoadSceneAsync(sceneName));
	}

	IEnumerator LoadSceneAsync(string sceneName)
    {
	    AsyncOperation sceneLoadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

	    while (!sceneLoadOperation.isDone)
	    {
		    //Debug.Log("LOAD SCENE: Progress: " + sceneLoadOperation.progress);

			loadingSlider.value = Mathf.Clamp01(sceneLoadOperation.progress / 0.9f);

		    yield return null;
	    }
	}
}
