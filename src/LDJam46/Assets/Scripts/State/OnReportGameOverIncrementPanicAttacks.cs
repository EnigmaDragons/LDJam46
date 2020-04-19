
using UnityEngine;

public class OnReportGameOverIncrementPanicAttacks : OnMessage<ReportGameOver>
{
    [SerializeField] private CurrentGameState game;

    protected override void Execute(ReportGameOver msg) => game.UpdateState(gs => gs.NumPanicAttacks += 1);
}
