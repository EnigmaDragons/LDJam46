using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        Message.Publish(new StartConversation(new []{ "Test", "Test2" }));
    }
}