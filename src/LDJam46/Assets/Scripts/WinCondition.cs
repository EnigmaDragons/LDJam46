using System.Collections;
using UnityEngine;

public class WinCondition : OnMessage<WorldSwapFinished>
{
    protected override void Execute(WorldSwapFinished msg)
    {
        if (msg.World == CurrentWorld.Real)
            StartCoroutine(Win());
    }

    protected IEnumerator Win()
    {
        yield return new WaitForSeconds(1);
        Message.Publish(new ReportVictory());
    }
}