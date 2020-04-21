﻿using UnityEngine;
using UnityEngine.UI;

public class DemonUI : MonoBehaviour
{
    [SerializeField] private DemonState demonState;
    [SerializeField] private Slider slider;

    private void Awake() => gameObject.SetActive(false);
    
    private void Update()
    {
        gameObject.SetActive(demonState.IsActive);
        slider.value = demonState.ProgressPercent;
    }
}