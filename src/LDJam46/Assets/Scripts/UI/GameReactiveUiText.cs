using TMPro;
using UnityEngine;

public abstract class GameReactiveUiText : OnMessage<GameStateChanged>
{
    [SerializeField] private CurrentGameState game;
    [SerializeField] private TextMeshProUGUI ui;

    private void Start() => ui.text = GetValue(game.GameState);

    protected abstract string GetValue(GameState game);
    protected override void Execute(GameStateChanged msg) => ui.text = GetValue(msg.State);
}
