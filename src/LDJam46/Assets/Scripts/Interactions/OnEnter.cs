using UnityEngine;
using UnityEngine.Events;

public class OnEnter : MonoBehaviour
{
    [SerializeField] private UnityEvent onTouch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            onTouch.Invoke();
    }
}