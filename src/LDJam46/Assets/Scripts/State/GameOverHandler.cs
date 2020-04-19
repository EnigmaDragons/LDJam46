
using UnityEngine;

public class GameOverHandler : OnMessage<ReportGameOver>
{
    [SerializeField] private GameObject activate;
    [SerializeField] private CurrentGameState gameState;

    protected override void Execute(ReportGameOver msg)
    {
        if (!gameState.GameState.HadPanicAttackToday)
        {
            gameState.UpdateState(x =>
            {
                x.HadPanicAttackToday = true;
                x.NumPanicAttacks++;
            });
            activate.SetActive(true);
            Message.Publish(new SwapWorld());
            Message.Publish(new StartNextDay());
        }
    }
}
