using UnityEngine;

public sealed class RoundRobinSceneBackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioClip[] musics;
    [SerializeField] private GameMusicPlayer musicPlayer;
    [SerializeField] private bool shouldLoop = true;

    private bool _shouldPlay;
    private IndexSelector<AudioClip> _musics;

    private void Awake() => _musics = new IndexSelector<AudioClip>(musics);
    
    private void OnEnable() => _shouldPlay = true;
    private void OnDisable() => _shouldPlay = false;
    
    private void Update()
    {
        if (!_shouldPlay)
            return;

        _shouldPlay = false;
        if (shouldLoop)
            musicPlayer.PlaySelectedMusicLooping(_musics.MoveNext());
        else 
            musicPlayer.PlayMusicOnce(_musics.MoveNext());
    }
}
