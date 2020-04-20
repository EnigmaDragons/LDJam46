
using UnityEngine;

public class ShowIfJouralEntryUnlocked : MonoBehaviour
{
    [SerializeField] private JournalEntry entry;
    [SerializeField] private CurrentGameState game;

    private void OnEnable()
    {
        if(!game.GameState.UnlockedJournalEntries.Contains(entry))
            gameObject.SetActive(false);
    }
}
