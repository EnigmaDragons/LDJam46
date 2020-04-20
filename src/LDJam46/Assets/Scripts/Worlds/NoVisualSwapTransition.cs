
public class NoVisualSwapTransition : OnMessage<WorldSwapStarted>
{
    protected override void Execute(WorldSwapStarted msg)
    {
        Message.Publish(new ReadyForWorldSwapPeak());
        Message.Publish(new ReadyForWorldSwapFinished());
    }
}
