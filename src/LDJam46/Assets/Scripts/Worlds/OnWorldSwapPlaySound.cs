
using UnityEngine;

public class OnWorldSwapPlaySound : OnMessage<WorldSwapStarted>
{
    [SerializeField] private UiSfxPlayer uiSounds;
    [SerializeField] private AudioClip clip;
    [SerializeField] private float volume = 0.5f;

    protected override void Execute(WorldSwapStarted msg)
    {
        uiSounds.Play(clip, volume);
    }
}
