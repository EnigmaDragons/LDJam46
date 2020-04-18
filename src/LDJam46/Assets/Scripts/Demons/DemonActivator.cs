using Assets.Scripts.Demons;
using UnityEngine;

public class DemonActivator : OnMessage<ActivateDemon, DeactivateAllDemons>
{
    [SerializeField] private GameObject pressure;
    
    protected override void Execute(ActivateDemon msg)
    {
        if (msg.Demon == DemonName.Pressure)
            pressure.SetActive(true);
    }

    protected override void Execute(DeactivateAllDemons msg)
    {
        pressure.SetActive(false);
    }
}
