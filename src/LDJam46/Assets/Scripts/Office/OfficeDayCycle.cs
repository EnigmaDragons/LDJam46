using UnityEngine;

public class OfficeLight : MonoBehaviour
{
	Light light2d;
	Color color1 = Color.red;
	Color color2 = Color.blue;
	Color color3 = Color.green;

	void Start()
	{
		light2d = GetComponent<Light>();
	}

	void Update()
	{
		light2d.color = color1;
	}
}