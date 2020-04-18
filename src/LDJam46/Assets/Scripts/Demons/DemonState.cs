
using Assets.Scripts.Demons;
using UnityEngine;

[CreateAssetMenu(menuName = "Demons/State")]
public class DemonState : ScriptableObject
{
    public DemonName Name;
    public bool IsActive;
    [SerializeField, Range(0f, 1f)] private float progressPercent;

    public float ProgressPercent => progressPercent;

    public void Activate()
    {
        IsActive = true;
        progressPercent = 0f;
    }

    public void Increment(float amount)
    {
        progressPercent += amount;
        if (progressPercent >= 1f) 
            Message.Publish(new ReportGameOver(Name));
    }
    
    public void Setback(float amount)
    {
        progressPercent -= amount;
        if (progressPercent <= 0)
            IsActive = false;
    }
}
