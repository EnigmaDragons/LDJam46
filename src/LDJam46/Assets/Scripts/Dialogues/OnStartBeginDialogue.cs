
using UnityEngine;

public class OnStartBeginDialogue : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    
    void Start() => Message.Publish(new StartConversation(dialogue));
}
