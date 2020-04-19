
using UnityEngine;

public class OnEnableRecordCharacterSpawnPoint : MonoBehaviour
{
    private void OnEnable() => Message.Publish(new RecordCharacterSpawnPoint(transform.position));
}
