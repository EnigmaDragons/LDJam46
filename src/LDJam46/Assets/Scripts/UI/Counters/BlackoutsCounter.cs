
public class BlackoutsCounter : GameReactiveUiText
{
    protected override string GetValue(GameState game) => $"Blackouts: {game.NumBlackouts}";
}
