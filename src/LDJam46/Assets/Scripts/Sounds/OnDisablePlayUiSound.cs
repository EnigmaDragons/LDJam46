using UnityEngine;

public class OnDisablePlayUiSound : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private float volume = 0.5f;
    [SerializeField] private UiSfxPlayer player;

    private void OnDisable() => player.Play(clip, volume);
}
