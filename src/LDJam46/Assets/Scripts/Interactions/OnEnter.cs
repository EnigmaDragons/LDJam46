using UnityEngine;
using UnityEngine.Events;

public class OnEnter : MonoBehaviour
{
    [SerializeField] private UnityEvent onTouch;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<SetAsPlayerCharacterOnEnable>() != null)
            onTouch.Invoke();
    }
}