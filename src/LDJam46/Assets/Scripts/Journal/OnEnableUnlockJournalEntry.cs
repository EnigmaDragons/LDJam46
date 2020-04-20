
using UnityEngine;

public class OnEnableUnlockJournalEntry : MonoBehaviour
{
    [SerializeField] private JournalEntry entry;

    private void OnEnable()
    {
        Message.Publish(new UnlockJournalEntry(entry));
    }
}
