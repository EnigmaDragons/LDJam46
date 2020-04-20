using UnityEngine;
using UnityEngine.UI;

public class OpacityBasedOnParanoiaDistance : OnMessage<ParanoiaDistance>
{
    [SerializeField] private ParticleSystem particleSystem;

    protected override void Execute(ParanoiaDistance msg)
    {
        throw new System.NotImplementedException();
    }
}