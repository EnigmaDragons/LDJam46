using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    [SerializeField] private bool trigger;
    [SerializeField] private UnityEvent action;
    
    private void Update()
    {
        if (trigger)
            action.Invoke();
        trigger = false;
    }
}