using UnityEngine;

public class StartSceneBackgroundMusicAfterGameOverScreen : MonoBehaviour
{
    [SerializeField] private AudioClip music;
    [SerializeField] private GameMusicPlayer musicPlayer;
    [SerializeField] private bool shouldLoop = true;
    [SerializeField] private CurrentGameState game;

    private bool _shouldPlay;

    private void OnEnable() => _shouldPlay = true;
    private void OnDisable() => _shouldPlay = false;
    
    private void Update()
    {
        if (!_shouldPlay || game.GameState.IsShowingGameOverScreen)
            return;

        _shouldPlay = false;
        if (shouldLoop)
            musicPlayer.PlaySelectedMusicLooping(music);
        else 
            musicPlayer.PlayMusicOnce(music);
    }
}
