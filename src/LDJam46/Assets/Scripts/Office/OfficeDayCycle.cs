using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class OfficeLight : MonoBehaviou
{
	Light2D light2d;
	Color color1 = Color.red;
	Color color2 = Color.blue;
	Color color3 = Color.green;

	void Start()
	{
		light2d = GetComponent<Light2D>();
	}

	void Update()
	{
		light2d.color = color1;
	}
}