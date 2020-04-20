using System;
using System.Collections;
using Assets.Scripts.Dialogues;
using UnityEngine;

public class DialogueBoxUI : OnMessage<StartConversation>
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private DialogueLineUI line;
    [SerializeField] private FloatReference inputCooldown;
    [SerializeField] private UiSfxPlayer audioSource;

    private Dialogue _dialogue;
    private int _index = 0;
    private float _cooldown = 0;
    private bool _playingDialogue = false;

    protected override void Execute(StartConversation msg)
    {
        _dialogue = msg.Dialogue;
        _index = 0;
        dialogueBox.SetActive(true);
        _playingDialogue = true;
        Resolve();
    }

    private void Update()
    {
        _cooldown -= Time.deltaTime;
        if (!_playingDialogue)
            return;
        line.ManualUpdate();
        if (_cooldown <= 0 && Input.GetButtonDown("Continue"))
        {
            _cooldown += inputCooldown.Value;
            Resolve();
        }
    }

    private void Resolve()
    {
        if (!_playingDialogue)
            return;
        
        if (!line.IsRevealed)
        {
            line.Reveal();
        }
        else if (_playingDialogue && _index == _dialogue.Lines.Count)
        {
            Debug.Log("Dialogue - Finished", gameObject);
            _playingDialogue = false;
            dialogueBox.SetActive(false);
            Message.Publish(new ConversationEnded());
        }
        else if (_dialogue.Lines[_index].Type == DialogueLineType.SoundEffect)
        {
            Debug.Log($"Dialogue - Playing Sound {_dialogue.Lines[_index].SoundEffect.name}", gameObject);
            audioSource.Play(_dialogue.Lines[_index].SoundEffect);
            _index++;
            WithDelay(0.8f, Resolve);
        }
        else if (_dialogue.Lines[_index].Type == DialogueLineType.Statement)
        {
            Debug.Log($"Dialogue - Displaying Statement {_dialogue.Lines[_index].Text}", gameObject);
            line.Display(_dialogue.Lines[_index].Text);
            _index++;
        }
        else if (_dialogue.Lines[_index].Type == DialogueLineType.VisualEffect)
        {
            var fx = _dialogue.Lines[_index].Effect;
            PlayDialogueEffect(fx);
            _index++;
        }
        else if (_dialogue.Lines[_index].Type == DialogueLineType.ActivateTrigger)
        {
            Debug.Log($"Dialogue - Activating Trigger {_dialogue.Lines[_index].TriggerName}", gameObject);
            Message.Publish(new ActivateTrigger(_dialogue.Lines[_index].TriggerName));
            _index++;
            Resolve();
        }
        else if (_dialogue.Lines[_index].Type == DialogueLineType.SwapWorld)
        {
            Debug.Log($"Dialogue - Swapping World", gameObject);
            Message.Publish(new SwapWorld());
            _index++;
            Resolve();
        }
    }

    private void PlayDialogueEffect(DialogueEffect fx)
    {
        if (fx == DialogueEffect.FadeIn)
        {
            Debug.Log("Dialogue - Starting Fade In", gameObject);
            Message.Publish(new StartFadeIn());
        }
        else if (fx == DialogueEffect.ShowJournal)
        {
            Debug.Log("Dialogue - Showing Journal", gameObject);
            Message.Publish(new ShowJournal());
        }
        else
        {
            Debug.Log($"Dialogue - Unimplemented Effect {fx.ToString()}", gameObject);
        }
    }

    private void WithDelay(float secondsToWait, Action action) 
        => StartCoroutine(ExecuteWithDelay(secondsToWait, action));

    private IEnumerator ExecuteWithDelay(float secondsToWait, Action action)
    {
        yield return new WaitForSeconds(secondsToWait);
        action();
    }
}