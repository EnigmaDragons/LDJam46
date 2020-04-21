
public class WorldSwapStarted
{
    public CurrentWorld NewWorld { get; }
    public bool Instantly { get; }

    public WorldSwapStarted(CurrentWorld newWorld, bool instantly)
    {
        NewWorld = newWorld;
        Instantly = instantly;
    }
}
