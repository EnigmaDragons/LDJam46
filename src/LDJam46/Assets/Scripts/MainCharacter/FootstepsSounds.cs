
using System.Collections;
using UnityEngine;

public class FootstepsSounds : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private float walkSeconds;
    [SerializeField] private float runSeconds;
    
    private IndexSelector<AudioClip> _clips;
    private float _secondsBetweenSteps;
    private bool _isMoving;
    private bool _readyToStart = true;

    private void Awake() => _clips = new IndexSelector<AudioClip>(clips);
    private void OnEnable() => _readyToStart = true;

    public void StartWalking()
    {
        _isMoving = true;
        _secondsBetweenSteps = walkSeconds;
        StartCoroutine(MakeSounds());
    }

    public void Stop()
    {
        _isMoving = false;
    }

    private IEnumerator MakeSounds()
    {
        if (_readyToStart)
            yield break;
        
        _readyToStart = false;
        while (_isMoving)
        {
            source.PlayOneShot(_clips.MoveNext());
            yield return new WaitForSeconds(_secondsBetweenSteps);
        }
        _readyToStart = true;
    }
}
