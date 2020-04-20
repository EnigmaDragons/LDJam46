
using UnityEngine;

public class OfficeTimeSpawnRule : OnMessage<GameStateChanged>
{
    [SerializeField] private int DayNumber;
    [SerializeField] private int NumDayBlackouts;
    [SerializeField] private GameObject target;

    private void Awake()
    {
        target.SetActive(false);
    }

    protected override void Execute(GameStateChanged msg)
    {
        Process(msg);
    }

    private void Process(GameStateChanged msg)
    {
        Debug.Log($"Day {msg.State.DayNumber} - Blackouts {msg.State.BlackoutsToday}");
        target.SetActive(msg.State.DayNumber == DayNumber && msg.State.BlackoutsToday == NumDayBlackouts);
    }
}
