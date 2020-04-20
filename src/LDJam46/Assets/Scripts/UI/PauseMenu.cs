using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
	[SerializeField] private GameObject overlay;
	[SerializeField] private GameObject optionsPanel;
	[SerializeField] private GameObject optionsPanelBackButton;

	[SerializeField] private Selectable firstSelectable;

	void Start()
    {
	    overlay.SetActive(false);
	    optionsPanelBackButton.SetActive(false);
	}

    void Update()
    {
	    if (Input.GetButtonDown("Pause") || Input.GetKeyDown(KeyCode.Escape))
	    {
		    if (overlay.activeSelf)
		    {
			    if (optionsPanel.activeSelf)
			    {
				    optionsPanel.SetActive(false);
				    firstSelectable.Select();
			    }
			    else
			    {
					Resume();
				}
		    }
		    else
		    {
			    Pause();
		    }
	    }
    }

    public void Pause()
    {
	    Time.timeScale = 0.0f;
	    overlay.SetActive(true);
	    optionsPanel.SetActive(false);
	}

    public void Resume()
    {
	    Time.timeScale = 1.0f;
	    overlay.SetActive(false);
	}

    public void ToggleOptionsPanel()
    {
	    optionsPanel.SetActive(!optionsPanel.activeSelf);
    }
}
