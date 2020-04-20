using System;
using Assets.Scripts.Dialogues;
using UnityEngine;

[Serializable]
public class DialogueLine
{
    public DialogueLineType Type;
    public string Text;
    public AudioClip SoundEffect;
    public DialogueEffect Effect;
    public string TriggerName;
    public Sprite Image;

    public DialogueLine Clone()
    {
        return new DialogueLine
        {
            Type = Type,
            Text = Text,
            SoundEffect = SoundEffect,
            Effect = Effect,
            TriggerName = TriggerName,
            Image = Image
        };
    }
}