
using UnityEngine;
using UnityEngine.UI;

public class UIFadeIn : OnMessage<StartFadeIn>
{
    [SerializeField] private Image sprite;
    [SerializeField] private float durationSeconds = 1.5f;

    private bool _isFading;
    private float _elapsed;

    public void Update()
    {
        if (!_isFading)
            return;

        _elapsed += Time.deltaTime;
        sprite.color = new Color(1f, 1f, 1f, Mathf.Lerp(1, 0, _elapsed / durationSeconds));
        if (_elapsed > durationSeconds)
            _isFading = false;
    }
    
    protected override void Execute(StartFadeIn msg)
    {
        _elapsed = 0;
        _isFading = true;
    }
}
