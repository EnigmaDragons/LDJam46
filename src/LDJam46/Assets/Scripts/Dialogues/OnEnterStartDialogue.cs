using System.Linq;
using UnityEngine;

public class OnEnterStartDialogue : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    private bool _isTriggered;

    private void OnCollisionEnter(Collision collision) => Execute(collision.gameObject);
    private void OnTriggerEnter(Collider collision) => Execute(collision.gameObject);
    private void OnCollisionEnter2D(Collision2D collision) => Execute(collision.gameObject);
    private void OnTriggerEnter2D(Collider2D collision) => Execute(collision.gameObject);

    private void Execute(GameObject o)
    {
        if (_isTriggered)
            return;
        
        _isTriggered = true;
        Message.Publish(new StartConversation(dialogue));   
    }
}
