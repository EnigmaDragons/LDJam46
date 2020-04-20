using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuControls : MonoBehaviour
{
	[SerializeField] private Navigator navigator;
	[SerializeField] private Animator animator;

	[SerializeField] private Selectable mainMenuSelectable;
	[SerializeField] private Selectable optionsSelectable;
	[SerializeField] private Selectable creditsSelectable;

	[SerializeField] private GameObject optionsPanel;
	[SerializeField] private GameObject creditsPanel;

	[SerializeField] private TMP_Text versionNumberText;
	[SerializeField] private StringVariable versionNumber;

	[SerializeField] private LoadingScreen loadingScreen;

	private void Start()
	{
		optionsPanel.SetActive(false);
		creditsPanel.SetActive(false);

		versionNumberText.text = 'v' + versionNumber.Value;
	}

	void Update()
    {
	    if (Input.GetButtonDown("Cancel"))
	    {
		    navigator.QuitGame();
	    }
    }

	public void MainMenuToOptions()
	{
		EventSystem.current.SetSelectedGameObject(null);
		animator.SetTrigger("MainMenuToOptions");
	}

	public void OptionsToMainMenu()
	{
		EventSystem.current.SetSelectedGameObject(null);
		animator.SetTrigger("OptionsToMainMenu");
	}

	public void MainMenuToCredits()
	{
		EventSystem.current.SetSelectedGameObject(null);
		animator.SetTrigger("MainMenuToCredits");
	}

	public void CreditsToMainMenu()
	{
		EventSystem.current.SetSelectedGameObject(null);
		animator.SetTrigger("CreditsToMainMenu");
	}

	public void MainMenuToGameScene()
	{
		animator.SetTrigger("MainMenuToGameScene");
	}

	public void ToGameSceneAnimationInitEvent()
	{
		loadingScreen.InitiLoad();
	}

	public void ToGameSceneAnimationEvent()
	{
		loadingScreen.LoadScene("GameScene");
	}
}
