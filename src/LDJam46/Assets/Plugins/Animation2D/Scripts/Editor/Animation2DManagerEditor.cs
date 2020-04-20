#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Animation2DManager))]
public class Animation2DManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Animation2DManager script = (Animation2DManager)target;

        Animation2D[] animations;
        animations = script.gameObject.GetComponents<Animation2D>();

        if (animations.Length > 0)
        {
            GUILayout.Label("Currently attached animations list", EditorStyles.boldLabel);

            for (int i = 0; i < animations.Length; i++)
            {
                GUILayout.Label("ID: " + i + " Name: " + animations[i].animationName);
            }
        }
        else
        {
            EditorGUILayout.HelpBox("There are no animations attached to gameobject.", MessageType.Warning);
        }

        for (int i = 0; i < animations.Length; i++)
        {
            for (int i2 = 0; i2 < animations.Length; i2++)
            {
                if (animations[i].animationName == animations[i2].animationName && i != i2)
                {
                    EditorGUILayout.HelpBox("Duplication found, both will be played at the same call, animations' name: " + animations[i].animationName, MessageType.Warning); return;
                }
            }
        }

        EditorGUILayout.HelpBox("Note that you can add more than 1 animation to this gameobject, manager will detect all and control them by their name, please use different names otherwise they'll be played at the same time.", MessageType.Info);
    }
}
#endif
