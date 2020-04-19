using UnityEngine;

public class IncrementDayCounter : OnMessage<StartNextDay>
{
    [SerializeField] private CurrentGameState gameState;
    protected override void Execute(StartNextDay msg) => gameState.UpdateState(x => x.DayNumber++);
}