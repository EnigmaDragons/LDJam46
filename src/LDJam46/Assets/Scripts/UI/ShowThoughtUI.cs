using System.Collections;
using UnityEngine;

public class ShowThoughtUI : OnMessage<ShowThought>
{
    [SerializeField] private FloatReference hideDelayDuration;
    [SerializeField] private ShowThoughtLineUI line;
    
    protected override void Execute(ShowThought msg)
    {
        line.Display(msg.Thought, () => StartCoroutine(HideAfterDelay()));
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(hideDelayDuration);
        line.gameObject.SetActive(false);
    }
}
