using UnityEngine;

public sealed class SceneBackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioClip music;
    [SerializeField] private GameMusicPlayer musicPlayer;
    [SerializeField] private bool shouldLoop = true;

    private void OnEnable()
    {
        if (shouldLoop)
            musicPlayer.PlaySelectedMusicLooping(music);
        else 
            musicPlayer.PlayMusicOnce(music);
    }
}
