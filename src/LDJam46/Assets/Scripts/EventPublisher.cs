﻿using UnityEngine;

public class EventPublisher : ScriptableObject
{
    public void PassTime(int minutes) => Message.Publish(new PassTime(minutes));
    public void GainItem(Item item) => Message.Publish(new GainItem(item));
}