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
    [SerializeField, Range(0f, 1f)] private float currentClosedAmount = 0f;

    private void OnEnable() => currentClosedAmount = 0;
    
    private void Update()
    {
        currentClosedAmount += closeSpeed * Time.deltaTime;
        var amount = Mathf.Lerp(fullyOpenScale, fullyClosedScale, currentClosedAmount);
        image.rectTransform.localScale = new Vector3(amount, amount, 1);
        if (currentClosedAmount >= 1f) 
            Message.Publish(new ReportGameOver(DemonName.Pressure));
    }
}
