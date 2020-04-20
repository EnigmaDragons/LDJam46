using System.Collections;
using UnityEngine;

public class WorldSwapTransitionV3 : OnMessage<WorldSwapStarted>
{
    [SerializeField] private GameObject anim;
    [SerializeField] private FloatReference midDuration;
    [SerializeField] private FloatReference fadeInDuration;

    private void Awake() => anim.SetActive(false);

    protected override void Execute(WorldSwapStarted msg) => StartCoroutine(Go());

    private IEnumerator Go()
    {
        anim.SetActive(true);
        yield return new WaitForSeconds(midDuration);
        Message.Publish(new ReadyForWorldSwapPeak());
        yield return new WaitForSeconds(fadeInDuration);
        anim.SetActive(false);
        Message.Publish(new ReadyForWorldSwapFinished());
    }
}