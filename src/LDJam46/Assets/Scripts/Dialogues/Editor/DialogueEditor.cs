#if UNITY_EDITOR
using System;
using System.Security.Cryptography.X509Certificates;
using Assets.Scripts.Dialogues;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(Dialogue)), CanEditMultipleObjects]
public class DialogueEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var dialogue = (Dialogue)target;
        AdjustItemCount(dialogue, EditorGUILayout.IntField("Size", dialogue.Lines.Count));
        var linesCopy = dialogue.Lines.ToArray();
        for (var i = 0; i < linesCopy.Length; i++)
        {
            var line = linesCopy[i];
            EditorGUILayout.Space();
            line.Type = (DialogueLineType) EditorGUILayout.EnumPopup("Type", line.Type);
            if (line.Type == DialogueLineType.Statement)
                TextField("Text", ref line.Text);
            else if (line.Type == DialogueLineType.SoundEffect)
                AudioClipField("Sound Effect", ref line.SoundEffect);
            else if (line.Type == DialogueLineType.VisualEffect)
                EnumPopup("Effect Type", ref line.Effect);
            else if (line.Type == DialogueLineType.ActivateTrigger)
                TextField("Trigger", ref line.TriggerName);
            else if (line.Type == DialogueLineType.ShowImage)
                SpriteField("Sprite", ref line.Image);
            if (GUILayout.Button("Insert"))
            {
                dialogue.Lines.Insert(i, line.Clone());
            }
            if (GUILayout.Button("Remove"))
            {
                dialogue.Lines.Remove(line);
            }
        }
    }

    private void AdjustItemCount(Dialogue dialogue, int newItemCount)
    {
        if (dialogue.Lines.Count != newItemCount)
        {
            while (newItemCount > dialogue.Lines.Count)
                dialogue.Lines.Add(new DialogueLine());
            while (newItemCount < dialogue.Lines.Count)
                dialogue.Lines.RemoveAt(dialogue.Lines.Count - 1);
            EditorUtility.SetDirty(target);
        }
    }

    private void TextField(string label, ref string text)
    {
        var oldText = text;
        text = EditorGUILayout.TextField(label, text);
        if (oldText != text)
            EditorUtility.SetDirty(target);
    }

    private void EnumPopup<T>(string label, ref T selected) where T : Enum
    {
        var oldSelected = selected;
        selected = (T)EditorGUILayout.EnumPopup(label, selected);
        if ((int)(object)oldSelected != (int)(object)selected)
            EditorUtility.SetDirty(target);
    }

    private void AudioClipField(string label, ref AudioClip clip)
    {
        var oldClip = clip;
        clip = (AudioClip)EditorGUILayout.ObjectField(label, clip, typeof(AudioClip), false);
        if (oldClip != clip)
            EditorUtility.SetDirty(target);
    }

    private void SpriteField(string label, ref Sprite sprite)
    {
        var oldSprite = sprite;
        sprite = (Sprite)EditorGUILayout.ObjectField(label, sprite, typeof(Sprite), false);
        if (oldSprite != sprite)
            EditorUtility.SetDirty(target);
    }
}
#endif
