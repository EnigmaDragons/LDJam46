
using UnityEngine;

public class ParanoiaDemonEncounterDialogue : OnMessage<ParanoiaDistance>
{
    [SerializeField] private float encounterDistance = 5f;
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private CurrentGameState game;
    
    protected override void Execute(ParanoiaDistance msg)
    {
        if (dialogue != null 
            && !game.GameState.CompletedDialogueKeys.Contains(DialogueKey.FirstParanoiaEncounter) 
            && msg.Distance <= encounterDistance)
        {
            game.UpdateState(g => g.CompletedDialogueKeys.Add(DialogueKey.FirstParanoiaEncounter));
            Message.Publish(new StartConversation(dialogue));
        }
    }
}
