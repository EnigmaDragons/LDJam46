
using UnityEngine;

public class OnEnableRecordSpawnPoint : MonoBehaviour
{
    private void OnEnable() => Message.Publish(new RecordCharacterSpawnPoint(transform.position));
}
