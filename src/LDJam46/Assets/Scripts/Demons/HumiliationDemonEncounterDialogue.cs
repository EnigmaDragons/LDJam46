
using UnityEngine;

public class HumiliationDemonEncounterDialogue : OnMessage<HumiliationImpDistance>
{
    [SerializeField] private float encounterDistance = 5f;
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private CurrentGameState game;
    
    protected override void Execute(HumiliationImpDistance msg)
    {
        if (dialogue != null 
            && !game.GameState.CompletedDialogueKeys.Contains(DialogueKey.FirstHumiliationEncounter) 
            && msg.Distance <= encounterDistance)
        {
            game.UpdateState(g => g.CompletedDialogueKeys.Add(DialogueKey.FirstHumiliationEncounter));
            Message.Publish(new StartConversation(dialogue));
        }
    }
}
