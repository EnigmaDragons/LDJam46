using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private Button nextDayButton;

    private void Awake()
    {
        nextDayButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            Message.Publish(new StartNextDay());
        });
    }
}
