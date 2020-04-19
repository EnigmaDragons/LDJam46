using UnityEngine;

public class OnStartGotoNextDay : MonoBehaviour
{
    private void Start() => Message.Publish(new StartNextDay());
}