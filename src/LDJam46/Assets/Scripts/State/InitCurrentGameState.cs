using UnityEngine;

public sealed class InitCurrentGameState : MonoBehaviour
{
    [SerializeField] private CurrentGameState state;
    [SerializeField] private DemonState[] demons;

    void Awake()
    {
        state.Init();
        demons.ForEach(d => d.Disable());
    }
}
