using Assets.Scripts.Demons;
using UnityEngine;

public class EventPublisher : ScriptableObject
{
    [SerializeField] private DemonState stress;
    [SerializeField] private DemonState humiliation;
    [SerializeField] private DemonState paranoia;

    public void PassTime(int minutes) => Message.Publish(new PassTime(minutes));
    public void GainItem(Item item) => Message.Publish(new GainItem(item));
    public void ConsumeComfort(Comfort comfort) => Message.Publish(new ComfortConsumed(comfort));
    public void ParanoiaGameOver()
    {
        if (paranoia.ProgressPercent >= 1)
            Message.Publish(new ReportGameOver(DemonName.Paranoia));
        else
        {
            stress.Increment(0.2f);
            humiliation.Increment(0.2f);
        }
    }
    public void HumiliationGameOver() => Message.Publish(new ReportGameOver(DemonName.Humiliation));
    public void StartNextDay() => Message.Publish(new StartNextDay());
    public void TestThought() => Message.Publish(new ShowThought("I am thinking a thought."));
}