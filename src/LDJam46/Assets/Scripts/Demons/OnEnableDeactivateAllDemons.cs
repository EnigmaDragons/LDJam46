using UnityEngine;

public class OnEnableDeactivateAllDemons : MonoBehaviour
{
    private void OnEnable() => Message.Publish(new DeactivateAllDemons());
}
