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
    public List<Item> Items { get; set; } = new List<Item>();
    public bool isInDialogue { get; set; } = false;
    public int NumPanicAttacks { get; set; } = 0;
    public int NumBlackouts { get; set; } = 0;
    public int DayNumber { get; set; } = 0;
    public bool HadPanicAttackToday { get; set; } = false;
}
