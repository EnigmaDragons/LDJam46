
using Assets.Scripts.Demons;
using UnityEngine;

public class InstaloseDay : MonoBehaviour
{
    public void Go() => Message.Publish(new ReportGameOver(DemonName.Stress));
}
