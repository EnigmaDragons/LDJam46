
using UnityEngine;

public class OnEnablePlayUiSound : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private float volume = 0.5f;
    [SerializeField] private UiSfxPlayer player;

    private void OnEnable() => player.Play(clip, volume);
}
