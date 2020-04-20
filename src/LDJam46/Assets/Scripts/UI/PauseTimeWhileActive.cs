
using UnityEngine;

public class PauseTimeWhileActive : MonoBehaviour
{
    void OnEnable() => Time.timeScale = 0;
    void OnDisable() => Time.timeScale = 1;
}
