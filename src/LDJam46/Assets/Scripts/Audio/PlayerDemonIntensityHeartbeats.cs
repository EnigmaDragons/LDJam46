using UnityEngine;

public class PlayerDemonIntensityHeartbeats : MonoBehaviour
{
    [SerializeField] private CurrentGameState game;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip slow;
    [SerializeField] private AudioClip med;
    [SerializeField] private AudioClip fast;
    [SerializeField] private DemonState[] demons;

    private void Awake()
    {
        source.loop = false;
    }
    
    private void Update()
    {
        if (game.GameState.CurrentWorld == CurrentWorld.Real)
        {
            if (source.isPlaying)
                source.Stop();
            return;
        }
        
        var intensity = 0f;
        for(var i = 0; i < demons.Length; i++)
            if (demons[i].IsActive)
                intensity = Mathf.Max(demons[i].ProgressPercent, intensity);

        var targetVolume = intensity < 0.25 ? 0f : (intensity * 0.5f) + 0.1f;
        var targetClip = med;
        if (intensity < 0.5f)
            targetClip = slow;
        if (intensity > 0.8f)
            targetClip = fast;
        
        if (!source.isPlaying)
        {
            source.clip = targetClip;
            source.Play();
        }
        source.volume = targetVolume;
    }
}
