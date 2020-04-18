using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStateUpdater : OnMessage<StartConversation, ConversationEnded>
{
    [SerializeField] private CurrentGameState state;

    protected override void Execute(StartConversation msg) {
        state.UpdateState(g => g.isInDialogue = true);
    }

    protected override void Execute(ConversationEnded msg) {
        state.UpdateState(g => g.isInDialogue = false);
    }
}
