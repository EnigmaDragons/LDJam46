using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SelectFirstSelectable : MonoBehaviour
{
	[SerializeField] private Selectable selectable;

	void OnEnable()
	{
		//EventSystem.current.SetSelectedGameObject(selectable.gameObject);
		selectable.Select();
	}

	void Update()
	{
		if (EventSystem.current.currentSelectedGameObject == null)
		{
			if (Math.Abs(Input.GetAxis("Vertical")) > 0.001 || Math.Abs(Input.GetAxis("Horizontal")) > 0.001)
			{
				//EventSystem.current.SetSelectedGameObject(selectable.gameObject);
				selectable.Select();
			}
		}
	}
}
