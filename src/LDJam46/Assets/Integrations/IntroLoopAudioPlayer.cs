using E7.Introloop;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu]
public class IntroLoopAudioPlayer : ScriptableObject
{
    [SerializeField] private IntroloopAudio currentClip;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private FloatReference reductionDb = new FloatReference(0f);
    [SerializeField] private string volumeValueName = "MusicVolume";

    public void Init()
    {
        IntroloopPlayer.Instance.SetMixerGroup(mixer.FindMatchingGroups(volumeValueName)[0]);
        currentClip = null;
    }
    
    public void PlaySelectedMusicLooping(IntroloopAudio clipToPlay)
    {
        if (clipToPlay == null) return;
        if (currentClip != null && currentClip.name == clipToPlay.name) return;
        
        currentClip = clipToPlay;
        IntroloopPlayer.Instance.Play(clipToPlay);
    
        var volume = PlayerPrefs.GetFloat(volumeValueName, 0.5f);
        mixer.SetFloat(volumeValueName, (Mathf.Log10(volume) * 20) - reductionDb);
    }
}
