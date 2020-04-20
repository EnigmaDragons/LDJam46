using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour {

    public Animation2DManager manager;
    public string name;

    void OnGUI()
    {
        if (GUILayout.Button("Play Animation Once"))
        {
            manager.Play(name, reverse: true, loop: false, restart: true);
        }

        if (GUILayout.Button("Play Animation Looped"))
        {
            manager.Play(name, reverse: true, loop: true, restart: true);
        }

        if (manager.isPlaying(name))
        {
            if (GUILayout.Button("Pause"))
            {
                manager.Pause(name);
            }
        }
        else
        {
            if (GUILayout.Button("Resume"))
            {
                manager.Resume(name);
            }
        }
    }
}
