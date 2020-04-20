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
    public List<JournalEntry> UnlockedJournalEntries = new List<JournalEntry>();
    public bool isInDialogue = false;
    public int NumPanicAttacks { get; set; } = 0;
    
    private int _numBlackouts = 0;
    public int NumBlackouts
    {
        get => _numBlackouts;
        set
        {
            _numBlackouts = value;
            BlackoutsToday++;
        }
    }
    
    private int _dayNumber = 0;
    public int DayNumber
    {
        get => _dayNumber;
        set
        {
            _dayNumber = value;
            BlackoutsToday = 0;
        }
    }
    public bool HadPanicAttackToday { get; set; } = false;
    public int BlackoutsToday { get; private set; } = 0;
}
