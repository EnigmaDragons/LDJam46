
using UnityEngine;

public class ShowIfJouralEntryUnlocked : MonoBehaviour
{
    [SerializeField] private JournalEntry entry;
    [SerializeField] private CurrentGameState game;
    [SerializeField] private GameObject target;

    private void OnEnable()
    {
        if (target != null)
            target.SetActive(game.GameState.UnlockedJournalEntries.Contains(entry));
    }
}
