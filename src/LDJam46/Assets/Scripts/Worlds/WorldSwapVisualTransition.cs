
using System;
using UnityEngine;

public class WorldSwapVisualTransition : MonoBehaviour
{
    [SerializeField] private Material transitionMaterial;
    [SerializeField] private float transitionSpeed = 0.01f;

    private Action _onFinished;
    private Action _onMidpoint;
    private bool _isActive;
    private bool _reachedMidpoint;
    private float _percentComplete;

    private void OnEnable() => Init();

    private void Init() => transitionMaterial.SetFloat("_Cutoff", 0);

    public void ShowTransition(Action onMidpoint, Action onFinished)
    {
        _onMidpoint = onMidpoint;
        _onFinished = onFinished;
        _reachedMidpoint = false;
        _isActive = true;
        _percentComplete = 0f;
    }

    private void Update()
    {
        if (!_isActive)
            return;

        if (!_reachedMidpoint)
            ProgressToMidpoint();
        else
            ProgressToEnd();
    }

    private void ProgressToEnd()
    {        
        _percentComplete -= transitionSpeed * Time.deltaTime;
         transitionMaterial.SetFloat("_Cutoff", Mathf.Lerp(0, 1, _percentComplete));
         if (_percentComplete <= 0)
         {
             _isActive = false;
             _onFinished();
             Init();
         }
    }

    private void ProgressToMidpoint()
    {
        _percentComplete += transitionSpeed * Time.deltaTime;
        transitionMaterial.SetFloat("_Cutoff", Mathf.Lerp(0, 1, _percentComplete));
        if (_percentComplete >= 1)
        {
            _reachedMidpoint = true;
            _onMidpoint();
        }
    }
}
