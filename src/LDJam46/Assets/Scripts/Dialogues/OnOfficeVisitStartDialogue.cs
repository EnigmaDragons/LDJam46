
using System.Linq;
using UnityEngine;

public class OnOfficeVisitStartDialogue : OnMessage<NewDayStarted, WorldSwapFinished>
{
    [SerializeField] private CurrentGameState game;
    [SerializeField] private Dialogue[] randomDefaultDialogues;
    [SerializeField] private TimeTriggeredDialogue[] dialogues;
    
    protected override void Execute(NewDayStarted msg) => StartDialogueIfApplicable();

    protected override void Execute(WorldSwapFinished msg)
    {
        if (msg.World == CurrentWorld.Real && !game.GameState.HadPanicAttackToday)
            StartDialogueIfApplicable();
    }

    private void StartDialogueIfApplicable()
    {
        var g = game.GameState;
        var possibleDialogues = dialogues.Where(d =>
            d.Day == g.DayNumber &&
            d.DayBlackoutNumber == g.BlackoutsToday + 1);
        if (possibleDialogues.Any())
            Message.Publish(new StartConversation(possibleDialogues.First().Dialogue));
        else
            Message.Publish(new StartConversation(randomDefaultDialogues.Random()));
    }
}
