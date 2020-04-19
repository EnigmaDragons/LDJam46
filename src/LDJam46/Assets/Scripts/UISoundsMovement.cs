﻿using UnityEngine;

public class UISoundsMovement : MonoBehaviour
{
	[SerializeField] private GameObject gameObjectToFollow;

    private void Start()
    {
	    if (gameObjectToFollow == null)
	    {
		    gameObjectToFollow = GameObject.FindGameObjectWithTag("MainCamera");

		    if (gameObjectToFollow == null)
		    {
				enabled = false;
			}
	    }
    }

    void Update()
    {
	    if (gameObjectToFollow != null)
			transform.position = gameObjectToFollow.transform.position;
    }
}
