using UnityEngine;

public class DialogueBoxUI : OnMessage<StartConversation>
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private DialogueLineUI line;
    [SerializeField] private FloatReference inputCooldown;

    private string[] _lines;
    private int _index;
    private float _cooldown = 0;

    protected override void Execute(StartConversation msg)
    {
        _lines = msg.Lines;
        _index = 0;
        dialogueBox.SetActive(true);
        line.Display(_lines[_index]);
    }

    private void Update()
    {
        _cooldown -= Time.deltaTime;
        if (_cooldown <= 0 && (Input.GetButtonDown("Continue") || Input.GetMouseButtonDown(0)))
        {
            _cooldown = inputCooldown.Value;
            if (line.IsRevealed && _index + 1 == _lines.Length)
            {
                dialogueBox.SetActive(false);
                Message.Publish(new ConversationEnded());
            }
            else if (line.IsRevealed)
            {
                _index++;
                line.Display(_lines[_index]);
            }
            else
            {
                line.Reveal();
            }
        }
    }
}