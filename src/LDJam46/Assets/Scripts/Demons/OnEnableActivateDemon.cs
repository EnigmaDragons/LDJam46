using Assets.Scripts.Demons;
using UnityEngine;

public class OnEnableActivateDemon : MonoBehaviour
{
    [SerializeField] private DemonName demon;
    
    void OnEnable() => Message.Publish(new ActivateDemon(demon));
}
