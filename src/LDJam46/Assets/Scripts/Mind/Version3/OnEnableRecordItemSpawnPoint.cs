
using UnityEngine;

public class OnEnableRecordItemSpawnPoint : MonoBehaviour
{
    private void OnEnable() => Message.Publish(new RecordItemSpawnPoint(transform.position));
}
