using UnityEngine;
using UnityEngine.UI;

public class DemonUI : MonoBehaviour
{
    [SerializeField] private DemonState demonState;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject target;

    private void Awake() => target.SetActive(false);
    
    private void Update()
    {
        target.SetActive(demonState.IsActive);
        slider.value = demonState.ProgressPercent;
    }
}