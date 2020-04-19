using System;
using System.Collections.Generic;

[Serializable]
public class PerComfort
{
    public Comfort Comfort;
    public float DefaultPercentage;
    public List<PerDemon> PerDemon;
}