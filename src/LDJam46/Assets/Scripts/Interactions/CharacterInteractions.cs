using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterInteractions : MonoBehaviour
{
    private List<Collider> _interactables = new List<Collider>();
    private Collider _interactable;

    private void OnTriggerEnter(Collider other)
    {
        var interactable = other.GetComponent<InteractableObject>();
        if (interactable != null)
            _interactables.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (_interactables.Contains(other))
        {
            _interactables.Remove(other);
            if (!_interactables.Any())
            {
                Message.Publish(new ClearAvailableInteraction());
                _interactable = null;
            }
        }
    }

    private void Update()
    {
        _interactables = _interactables.Where(x => x.gameObject.activeInHierarchy).ToList();
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