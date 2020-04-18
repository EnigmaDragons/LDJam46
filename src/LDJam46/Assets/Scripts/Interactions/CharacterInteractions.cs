using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterInteractions : MonoBehaviour
{
    private List<Collider2D> _interactables = new List<Collider2D>();
    private Collider2D _interactable;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var interactable = other.GetComponent<InteractableObject>();
        if (interactable != null)
            _interactables.Add(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_interactables.Contains(other))
        {
            _interactables.Remove(other);
            if (!_interactables.Any())
                Message.Publish(new ClearAvailableInteraction());
        }
    }

    private void Update()
    {
        if (_interactables.Any())
        {
            var closestInteractable = _interactables.OrderBy(x => Vector2.Distance(x.ClosestPoint(transform.localPosition), gameObject.transform.localPosition)).First();
            if (closestInteractable != _interactable)
            {
                _interactable = closestInteractable;
                var interactableComponent = _interactable.GetComponent<InteractableObject>();
                Message.Publish(new SetAvailableInteraction(interactableComponent.Name, interactableComponent.Event.Invoke));
            }
        }
    }
}