
using System.Linq;
using UnityEngine;

public class JournalCompletionDisplay : GameReactiveUiText
{
    [SerializeField] private int TotalUnlockables = 8;

    protected override string GetValue(GameState game) =>
        $"Completion: {game.UnlockedJournalEntries.Distinct().Count()}/{TotalUnlockables}";
}
