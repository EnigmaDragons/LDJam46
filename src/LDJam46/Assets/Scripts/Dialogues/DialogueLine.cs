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
}