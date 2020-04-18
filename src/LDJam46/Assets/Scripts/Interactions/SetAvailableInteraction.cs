using System;

public class SetAvailableInteraction
{
    public string Name { get; }
    public Action OnInteract { get; }

    public SetAvailableInteraction(string name, Action onInteract)
    {
        Name = name;
        OnInteract = onInteract;
    }
}