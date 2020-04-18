using UnityEngine;

public class CharacterInteractions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var interactable = other.GetComponent<InteractableObject>();
        if (interactable != null)
            Message.Publish(new SetAvailableInteraction(interactable.Name, interactable.Event.Invoke));
    }
}