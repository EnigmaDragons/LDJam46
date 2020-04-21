using UnityEngine;

public class EventTriggerSoundGuy : MonoBehaviour
{
    [SerializeField] private UiSfxPlayer player;
    [SerializeField] private AudioClipWithVolume itemCollected;
    [SerializeField] private AudioClipWithVolume[] headphonesFanfares;
    
    private void OnEnable()
    {
        Message.Subscribe<GainItem>(_ => PlayItemCollected(), this);
        Message.Subscribe<ComfortConsumed>(msg => PlayComfortConsumedSound(msg), this);
    }

    private void OnDisable() => Message.Unsubscribe(this);

    private void PlayComfortConsumedSound(ComfortConsumed c)
    {
        if (c.Comfort.JournalEntry == JournalEntry.ComfortMusic)
            PlayHeadphonesFanfare();
    }
    
    private void PlayItemCollected() => Play(itemCollected);
    private void PlayHeadphonesFanfare() => Play(headphonesFanfares.Random());

    private void Play(AudioClipWithVolume a) => player.Play(a.Clip, a.Volume);
}
