using System;
using System.Collections;
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
        if (!line.IsRevealed)
        {
            line.Reveal();
        }
        else if (_index == _dialogue.Lines.Count)
        {
            _playingDialogue = false;
            dialogueBox.SetActive(false);
            Message.Publish(new ConversationEnded());
        }
        else if (_dialogue.Lines[_index].Type == DialogueLineType.SoundEffect)
        {
            audioSource.Play(_dialogue.Lines[_index].SoundEffect);
            _index++;
            WithDelay(0.8f, Resolve);
        }
        else if (_dialogue.Lines[_index].Type == DialogueLineType.Statement)
        {
            line.Display(_dialogue.Lines[_index].Text);
            _index++;
        }
        else if (_dialogue.Lines[_index].Type == DialogueLineType.VisualEffect)
        {
            Message.Publish(new StartFadeIn());
            _index++;
        }
        else if (_dialogue.Lines[_index].Type == DialogueLineType.ActivateTrigger)
        {
            Message.Publish(new ActivateTrigger(_dialogue.Lines[_index].TriggerName));
            _index++;
            Resolve();
        }
        else if (_dialogue.Lines[_index].Type == DialogueLineType.SwapWorld)
        {
            Message.Publish(new SwapWorld());
            _index++;
            Resolve();
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