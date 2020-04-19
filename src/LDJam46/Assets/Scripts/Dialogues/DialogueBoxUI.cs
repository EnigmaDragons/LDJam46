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
        else if (_index + 1 == _dialogue.Lines.Count)
        {
            _playingDialogue = false;
            dialogueBox.SetActive(false);
            Message.Publish(new ConversationEnded());
            _dialogue.Event.Invoke();
        }
        else if (_dialogue.Lines[_index].Type == DialogueLineType.SoundEffect)
        {
            audioSource.Play(_dialogue.Lines[_index].SoundEffect);
            _index++;
            Resolve();
        }
        else if (_dialogue.Lines[_index].Type == DialogueLineType.Statement)
        {
            line.Display(_dialogue.Lines[_index].Text);
            _index++;
        }
        else if (_dialogue.Lines[_index].Type == DialogueLineType.VisualEffect)
        {
            _index++;
        }
    }
}