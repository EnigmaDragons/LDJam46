using System.Collections;
using UnityEngine;

public class WinCondition : OnMessage<WorldSwapStarted>
{
    [SerializeField] private CurrentGameState gameState;

    protected override void Execute(WorldSwapStarted msg)
    {
        if (msg.NewWorld == CurrentWorld.Real && !gameState.GameState.HadPanicAttackToday)
            StartCoroutine(Win());
    }

    protected IEnumerator Win()
    {
        yield return new WaitForSeconds(3);
        Message.Publish(new ReportVictory());
    }
}