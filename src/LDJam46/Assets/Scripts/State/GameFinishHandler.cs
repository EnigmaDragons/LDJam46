
using UnityEngine;

public class GameFinishHandler : OnMessage<ReportGameOver>
{
    [SerializeField] private Navigator navigator;
    
    protected override void Execute(ReportGameOver msg)
    {
        navigator.NavigateToGameOver();
    }
}
