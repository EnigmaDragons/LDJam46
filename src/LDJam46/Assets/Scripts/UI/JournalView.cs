
using UnityEngine;

public class JournalView : MonoBehaviour
{
    [SerializeField] private GameObject journalView;
    
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
}
