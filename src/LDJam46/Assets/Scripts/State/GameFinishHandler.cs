
using UnityEngine;

public class GameFinishHandler : OnMessage<ReportVictory>
{
    [SerializeField] private Navigator navigator;
    
    protected override void Execute(ReportVictory msg) => navigator.NavigateToVictory();
}
