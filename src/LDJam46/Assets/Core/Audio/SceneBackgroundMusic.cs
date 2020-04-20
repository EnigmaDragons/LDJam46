using UnityEngine;

public sealed class SceneBackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioClip music;
    [SerializeField] private GameMusicPlayer musicPlayer;
    [SerializeField] private bool shouldLoop = true;

    private bool _shouldPlay;

    private void OnEnable() => _shouldPlay = true;
    private void OnDisable() => _shouldPlay = false;
    
    private void Update()
    {
        if (!_shouldPlay)
            return;

        _shouldPlay = false;
        if (shouldLoop)
            musicPlayer.PlaySelectedMusicLooping(music);
        else 
            musicPlayer.PlayMusicOnce(music);
    }
}
