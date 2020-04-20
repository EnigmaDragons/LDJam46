using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
	[SerializeField] private Slider loadingSlider;
	[SerializeField] private GameObject forHiding;
	[SerializeField] private Animator backgroundAnimator;

	private bool _mandatoryWaitOver = false;

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
		StartCoroutine(MandatoryWait());
		StartCoroutine(LoadSceneAsync(sceneName));
	}

	private IEnumerator MandatoryWait()
	{
		yield return new WaitForSeconds(3.5f);

		_mandatoryWaitOver = true;
	}

	private IEnumerator LoadSceneAsync(string sceneName)
    {
	    AsyncOperation sceneLoadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
		sceneLoadOperation.allowSceneActivation = false;

	    while (!sceneLoadOperation.isDone)
	    {
		    //Debug.Log("LOAD SCENE: Progress: " + sceneLoadOperation.progress);

			loadingSlider.value = sceneLoadOperation.progress;

			if (_mandatoryWaitOver && sceneLoadOperation.progress >= 0.89f)
			{
				sceneLoadOperation.allowSceneActivation = true;
			}

		    yield return null;
	    }
	}
}
