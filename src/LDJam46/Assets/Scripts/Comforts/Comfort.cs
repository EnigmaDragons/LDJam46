using UnityEngine;

[CreateAssetMenu(menuName = "Comfort")]
public class Comfort : ScriptableObject
{
    public float DefaultPercentage;
    public PerDemon[] ComfortLevels;
    public JournalEntry JournalEntry;
}
