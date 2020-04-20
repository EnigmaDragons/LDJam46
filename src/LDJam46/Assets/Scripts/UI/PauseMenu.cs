using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
	[SerializeField] private GameObject overlay;
	[SerializeField] private GameObject optionsPanel;
	[SerializeField] private GameObject optionsPanelBackButton;
	[SerializeField] private GameObject controlsPanel;
	[SerializeField] private Selectable firstSelectable;

	void Start()
    {
	    overlay.SetActive(false);
	    optionsPanelBackButton.SetActive(false);
		controlsPanel.SetActive(false);
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
	    overlay.SetActive(true);
	    optionsPanel.SetActive(false);
	    controlsPanel.SetActive(false);
	}

    public void Resume()
    {
	    overlay.SetActive(false);
	}

    public void ToggleOptionsPanel()
    {
	    if (optionsPanel.activeSelf)
	    {
		    optionsPanel.SetActive(false);
	    }
	    else
	    {
		    optionsPanel.SetActive(true);
		    controlsPanel.SetActive(false);
	    }
	}

    public void ToggleControlsPanel()
    {
	    if (controlsPanel.activeSelf)
	    {
			controlsPanel.SetActive(false);
		}
	    else
	    {
			controlsPanel.SetActive(true);
			optionsPanel.SetActive(false);
		}
    }
}
