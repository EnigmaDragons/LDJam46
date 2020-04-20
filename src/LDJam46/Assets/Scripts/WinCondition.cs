using System.Collections;
using UnityEngine;

public class WinCondition : OnMessage<WorldSwapStarted>
{
    [SerializeField] private CurrentGameState gameState;

    protected override void Execute(WorldSwapStarted msg)
    {
        if (msg.NewWorld == CurrentWorld.Real && !gameState.GameState.HadPanicAttackToday && gameState.GameState.BlackoutsToday == 3)
            StartCoroutine(Win());
    }

    protected IEnumerator Win()
    {
        yield return new WaitForSeconds(3);
        Message.Publish(new ReportVictory());
    }
}