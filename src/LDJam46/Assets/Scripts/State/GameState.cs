using System;
using System.Collections.Generic;

[Serializable]
public sealed class GameState
{
    // Should consist of only serializable primitives.
    // Any logic or non-trivial data should be enriched in CurrentGameState.
    // Except for Save/Load Systems, everything should use CurrentGameState,
    // instead of this pure data structure.
    
    // All enums used in this class should have specified integer values.
    // This is necessary to preserve backwards save compatibility.
    public CurrentWorld CurrentWorld { get; set; } = CurrentWorld.Real;
    public List<string> Items { get; set; } = new List<string>();
}
