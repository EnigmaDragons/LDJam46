using UnityEngine;

public class EventTriggerSoundGuy : MonoBehaviour
{
    [SerializeField] private UiSfxPlayer player;
    [SerializeField] private AudioClipWithVolume itemCollected;
    
    private void OnEnable()
    {
        Message.Subscribe<GainItem>(_ => PlayItemCollected(), this);
    }

    private void OnDisable() => Message.Unsubscribe(this);

    private void PlayItemCollected() => player.Play(itemCollected.Clip, itemCollected.Volume);
}
