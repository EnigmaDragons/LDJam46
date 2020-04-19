using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] private GameObject overlay;

    void Start()
    {
	    overlay.SetActive(false);
    }

    void Update()
    {
	    if (Input.GetButtonDown("Pause") || Input.GetKeyDown(KeyCode.Escape))
	    {
		    if (overlay.activeSelf)
		    {
			    Resume();
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
	}

    public void Resume()
    {
	    Time.timeScale = 1.0f;
	    overlay.SetActive(false);
	}
}
