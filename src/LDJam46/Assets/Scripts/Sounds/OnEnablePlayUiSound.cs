
using UnityEngine;

public class OnEnablePlayUiSound : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private float volume = 0.5f;
    [SerializeField] private UiSfxPlayer player;

    private bool _shouldPlay;

    private void OnEnable() => _shouldPlay = true;
    private void OnDisable() => _shouldPlay = false;

    private void Update()
    {
        if (!_shouldPlay) return;

        _shouldPlay = false;
        player.Play(clip, volume);
    }
}
