using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public Sprite Sprite;
    public string Name;
    public List<PerComfort> ComfortBonuses;
}