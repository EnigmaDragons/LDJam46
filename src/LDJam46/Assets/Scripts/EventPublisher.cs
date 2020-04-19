using Assets.Scripts.Demons;
using UnityEngine;

public class EventPublisher : ScriptableObject
{
    public void PassTime(int minutes) => Message.Publish(new PassTime(minutes));
    public void GainItem(Item item) => Message.Publish(new GainItem(item));
    public void ConsumeComfort(Comfort comfort) => Message.Publish(new ComfortConsumed(comfort));
    public void ParanoiaGameOver() => Message.Publish(new ReportGameOver(DemonName.Paranoia));
    public void StartNextDay() => Message.Publish(new StartNextDay());
    public void TestThought() => Message.Publish(new ShowThought("I am thinking a thought."));
}