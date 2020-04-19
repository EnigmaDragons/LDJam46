
using UnityEngine;

public class GameOverHandler : OnMessage<ReportGameOver>
{
    [SerializeField] private GameObject activate;
    
    protected override void Execute(ReportGameOver msg) => activate.SetActive(true);
}
