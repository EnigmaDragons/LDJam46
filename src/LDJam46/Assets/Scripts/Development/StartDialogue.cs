
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    
    public void Execute() => Message.Publish(new StartConversation(dialogue));
}
