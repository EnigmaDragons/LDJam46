
using UnityEngine;

public class JournalView : OnMessage<ShowJournal>
{
    [SerializeField] private GameObject journalView;
    [SerializeField] private CurrentGameState game;

    private bool _queueShowJournal = false;

    private void Update()
    {
        if (!_queueShowJournal || game.GameState.isInDialogue) return;

        _queueShowJournal = false;
        Show();
    }
    
    public void Toggle()
    {
        if (journalView.activeSelf)
            Hide();
        else
            Show();
    }
    
    public void Show()
    {
        journalView.SetActive(true);
    }

    public void Hide()
    {
        journalView.SetActive(false);
    }

    protected override void Execute(ShowJournal msg) => _queueShowJournal = true;
}
