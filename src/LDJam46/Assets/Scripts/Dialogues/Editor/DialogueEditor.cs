using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Dialogue)), CanEditMultipleObjects]
public class DialogueEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var dialogue = (Dialogue)target;
        AdjustItemCount(dialogue, EditorGUILayout.IntField("Size", dialogue.Lines.Count));
        foreach (var line in dialogue.Lines)
        {
            EditorGUILayout.Space();
            line.Type = (DialogueLineType) EditorGUILayout.EnumPopup("Type", line.Type);
            if (line.Type == DialogueLineType.Statement)
                line.Text = EditorGUILayout.TextField("Text", line.Text);
            else if (line.Type == DialogueLineType.SoundEffect)
                line.SoundEffect = (AudioClip)EditorGUILayout.ObjectField("Sound Effect", line.SoundEffect, typeof(AudioClip), allowSceneObjects:false);
        }
        EditorGUILayout.Space();
        SerializedProperty sprop = serializedObject.FindProperty("Event");
        EditorGUILayout.PropertyField(sprop);
        serializedObject.ApplyModifiedProperties();
    }

    private void AdjustItemCount(Dialogue dialogue, int newItemCount)
    {
        if (dialogue.Lines.Count != newItemCount)
        {
            while (newItemCount > dialogue.Lines.Count)
                dialogue.Lines.Add(new DialogueLine());
            while (newItemCount < dialogue.Lines.Count)
                dialogue.Lines.RemoveAt(dialogue.Lines.Count - 1);
        }
    }
}