using UnityEngine;

public class UISoundsMovement : MonoBehaviour
{
	[SerializeField] private GameObject gameObjectToFollow;

    private void Start()
    {
	    if (gameObjectToFollow == null)
	    {
		    enabled = false;
	    }
    }

    void Update()
    {
	    transform.position = gameObjectToFollow.transform.position;
    }
}
