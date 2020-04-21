using System.Collections;
using UnityEngine;

public class WorldSwapTransitionV3 : OnMessage<WorldSwapStarted>
{
    [SerializeField] private GameObject anim;
    [SerializeField] private FloatReference midDuration;
    [SerializeField] private FloatReference fadeInDuration;

    private void Awake() => anim.SetActive(false);

    protected override void Execute(WorldSwapStarted msg)
    {
        if (msg.Instantly)
            StartCoroutine(Instantly());
        else
            StartCoroutine(WithAnim());
    }

    private IEnumerator Instantly()
    {
        Debug.Log($"World Swap - Instant Ready For Swap");
        Message.Publish(new ReadyForWorldSwapPeak());
        yield return new WaitForSeconds(0.1f);
        Message.Publish(new ReadyForWorldSwapFinished());
        Debug.Log($"World Swap - Instant - Ready For Game");
    }
    
    private IEnumerator WithAnim()
    {
        anim.SetActive(true);
        yield return new WaitForSeconds(midDuration);
        Debug.Log($"World Swap - Ready For Swap");
        Message.Publish(new ReadyForWorldSwapPeak());
        yield return new WaitForSeconds(fadeInDuration);
        anim.SetActive(false);
        Debug.Log($"World Swap - Ready For Game");
        Message.Publish(new ReadyForWorldSwapFinished());
    }
}