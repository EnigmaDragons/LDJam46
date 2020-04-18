
public class WorldSwapStarted
{
    public CurrentWorld NewWorld { get; }

    public WorldSwapStarted(CurrentWorld newWorld) => NewWorld = newWorld;
}
