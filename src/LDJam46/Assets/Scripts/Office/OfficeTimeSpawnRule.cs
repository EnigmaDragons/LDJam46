using UnityEngine;

public class OfficeTimeSpawnRule : OnMessage<GameStateChanged, WorldSwapPeaked>
{
    [SerializeField] private int DayNumber;
    [SerializeField] private int NumDayBlackouts;
    [SerializeField] private GameObject target;
    [SerializeField] private bool IsFinalContent;

    private GameState currentState;
    
    private void Awake() => target.SetActive(false);

    protected override void Execute(GameStateChanged msg)
    {
        currentState = msg.State;
        Process();
    }

    protected override void Execute(WorldSwapPeaked msg) => Process();

    private void Process()
    {
        var day = currentState.DayNumber;
        var numBlackouts = currentState.BlackoutsToday;
        if (IsFinalContent)
            target.SetActive(day > DayNumber || day == DayNumber && numBlackouts >= NumDayBlackouts);
        else
            target.SetActive(day == DayNumber && numBlackouts == NumDayBlackouts);
    }
}
