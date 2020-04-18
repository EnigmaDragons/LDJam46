using Assets.Scripts.Demons;
using UnityEngine;

public class DemonActivator : OnMessage<ActivateDemon, DeactivateAllDemons>
{
    [SerializeField] private PressureCloseIn pressure;
    
    protected override void Execute(ActivateDemon msg)
    {
        if (msg.Demon == DemonName.Pressure)
            pressure.Activate();
    }

    protected override void Execute(DeactivateAllDemons msg)
    {
        pressure.Deactivate();
    }
}
