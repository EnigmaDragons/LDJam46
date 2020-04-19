
using System.Collections;
using UnityEngine;

public class OnStartBeginDialogue : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private FloatReference delaySeconds = new FloatReference(0f);

    void Start() => StartCoroutine(BeginWithDelay());

    private IEnumerator BeginWithDelay()
    {
        yield return new WaitForSeconds(delaySeconds);
        Message.Publish(new StartConversation(dialogue));
    }
}
