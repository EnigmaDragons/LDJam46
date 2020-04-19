
public class PanicAttacksCounter : GameReactiveUiText
{
    protected override string GetValue(GameState game) => $"Panic Attacks: {game.NumPanicAttacks}";
}
