using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        Message.Publish(new PassTime(100));
    }
}