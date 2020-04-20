
using UnityEngine;

public class NewWorldVisualTransition : OnMessage<WorldSwapStarted>
{
    [SerializeField] private FloatReference timeUntilMidpoint = new FloatReference(2f);
    [SerializeField] private GameObject transition;

    private float _remaining;
    private bool _isActive;
    
    public void ShowTransition()
    {
        _isActive = true;
        _remaining = timeUntilMidpoint;
        transition.SetActive(true);
    }

    private void Update()
    {
        if (!_isActive)
            return;
        
        _remaining -= Time.deltaTime;
        if (_remaining < 0)
        {
            Message.Publish(new ReadyForWorldSwapPeak());
            Message.Publish(new ReadyForWorldSwapFinished());
            _isActive = false;
            transition.gameObject.SetActive(false);
        }
    }

    protected override void Execute(WorldSwapStarted msg)
    {
        ShowTransition();
    }
}
