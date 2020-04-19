using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuControls : MonoBehaviour
{
	[SerializeField] private Navigator navigator;
	[SerializeField] private Animator animator;

	private Selectable mainMenuSelectable;
	[SerializeField] private Selectable optionsSelectable;
	[SerializeField] private Selectable creditsSelectable;

	[SerializeField] private GameObject optionsPanel;
	[SerializeField] private GameObject creditsPanel;

	private void Start()
	{
		optionsPanel.SetActive(false);
		creditsPanel.SetActive(false);

		// this is really ugly but it works
		mainMenuSelectable = transform.Find("MenuButtonsPanel").GetChild(0).GetComponent<Selectable>();
		EventSystem.current.SetSelectedGameObject(mainMenuSelectable.gameObject);
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
}
