
using UnityEngine;

public class EnableTargetAfterGameOverScreen : OnMessage<GameStateChanged>
{
    [SerializeField] private GameObject target;
    [SerializeField] private CurrentGameState game;

    private bool _shouldEnable;
    
    private void OnEnable()
    {
        if (game.GameState.IsShowingGameOverScreen)
        {
            target.SetActive(false);
            _shouldEnable = true;
        }
        else
            target.SetActive(true);
    }

    private void OnDisable() => target.SetActive(false);

    protected override void Execute(GameStateChanged msg)
    {
        if (!_shouldEnable || msg.State.IsShowingGameOverScreen)
            return;

        _shouldEnable = false;
        target.SetActive(true);
    }
}
