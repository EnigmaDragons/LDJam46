using Assets.Scripts.Demons;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class PressureCloseIn : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private float fullyOpenScale = 1.6f;
    [SerializeField] private float fullyClosedScale = 0.002f;
    [SerializeField] private float closeSpeed = 0.5f;
    [SerializeField] private DemonState state;
    [SerializeField] private AudioSource voices;

    private void OnEnable() => state.Activate();
    
    private void Update()
    {
        state.Increment(closeSpeed * Time.deltaTime);
        var amount = Mathf.Lerp(fullyOpenScale, fullyClosedScale, state.ProgressPercent);
        image.rectTransform.localScale = new Vector3(amount, amount, 1);
        
        UpdateSounds();

        if (state.ProgressPercent >= 1)
            Message.Publish(new ReportGameOver(DemonName.Stress));
    }

    private void UpdateSounds()
    {
        if (!voices.isPlaying && state.ProgressPercent >= 0.6f)
        {
            StartCoroutine(AudioFadeUtils.FadeIn(voices, 0.5f));
        }

        if (voices.isPlaying && state.ProgressPercent < 0.6f)
        {
            StartCoroutine(AudioFadeUtils.FadeOut(voices, 0.5f));
        }
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        state.Activate();
    }

    public void Deactivate()
    {
        state.IsActive = false;
        gameObject.SetActive(false);
    }
}
