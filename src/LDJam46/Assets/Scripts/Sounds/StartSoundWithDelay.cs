using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StartSoundWithDelay : MonoBehaviour
{
    [SerializeField] private float delay;

    private void OnEnable() => StartCoroutine(Execute(GetComponent<AudioSource>()));

    private IEnumerator Execute(AudioSource src)
    {
        yield return new WaitForSeconds(delay);
        src.Play();
    }
}
