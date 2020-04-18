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

    private void OnEnable() => state.Activate();
    
    private void Update()
    {
        state.Increment(closeSpeed * Time.deltaTime);
        var amount = Mathf.Lerp(fullyOpenScale, fullyClosedScale, state.ProgressPercent);
        image.rectTransform.localScale = new Vector3(amount, amount, 1);
    }

    public void Activate() => gameObject.SetActive(true);
    public void Deactivate()
    {
        state.IsActive = false;
        gameObject.SetActive(false);
    }
}
