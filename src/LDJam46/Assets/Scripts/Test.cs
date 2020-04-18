using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        Message.Publish(new PassTime(100));
        Message.Publish(new StartConversation(new []{ "Test", "Test2" }));
    }
}