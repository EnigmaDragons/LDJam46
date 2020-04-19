
public class DayCounter : GameReactiveUiText
{
    protected override string GetValue(GameState game) => $"Day: {game.DayNumber}";
}
