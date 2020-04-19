using UnityEngine;

public class MainMenuControls : MonoBehaviour
{
	[SerializeField] private Navigator navigator;

	void Update()
    {
	    if (Input.GetAxis("Cancel") > 0.001)
	    {
		    navigator.QuitGame();
	    }
    }
}
