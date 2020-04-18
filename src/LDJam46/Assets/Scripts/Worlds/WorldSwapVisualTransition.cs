
using System;
using UnityEngine;

public class WorldSwapVisualTransition : MonoBehaviour
{
    [SerializeField] private Material transitionMaterial;
    [SerializeField] private float transitionSpeed;

    private Action _onFinished;
    private bool _isActive;
    private float percentComplete;
    
    public void ShowTransition(Action onFinished)
    {
        // TODO: Finish this
        _onFinished = onFinished;
    }

    private void Update()
    {
        
    }
}
