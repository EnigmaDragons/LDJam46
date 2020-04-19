using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public List<DialogueLine> Lines = new List<DialogueLine>();
}
