using UnityEngine;

public class JournalUnlocker : OnMessage<UnlockJournalEntry>
{
    [SerializeField] private CurrentGameState game;
    
    protected override void Execute(UnlockJournalEntry msg)
    {
        Debug.Log($"Journal - Unlocked {msg.Entry.ToString()}");
        game.UpdateState(gs => gs.UnlockedJournalEntries.Add(msg.Entry));
    }
}
