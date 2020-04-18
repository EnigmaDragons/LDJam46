
using UnityEngine;

public class GameFinishHandler : OnMessage<ReportGameOver, ReportVictory>
{
    [SerializeField] private Navigator navigator;
    
    protected override void Execute(ReportGameOver msg)
    {
        navigator.NavigateToGameOver();
    }

    protected override void Execute(ReportVictory msg) => navigator.NavigateToVictory();
}
