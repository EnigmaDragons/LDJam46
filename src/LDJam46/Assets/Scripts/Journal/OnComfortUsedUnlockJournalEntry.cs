
public class OnComfortUsedUnlockJournalEntry : OnMessage<ComfortConsumed>
{
    protected override void Execute(ComfortConsumed msg)
    {
        if (msg.Comfort.JournalEntry != JournalEntry.None)
            Message.Publish(new UnlockJournalEntry(msg.Comfort.JournalEntry));
    }
}
