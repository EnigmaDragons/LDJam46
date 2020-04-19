
using UnityEngine;

public class PutMainCharacterAtMindMapSpawnPoint : OnMessage<MapGenerated>
{
    [SerializeField] private GameObject body;
    
    protected override void Execute(MapGenerated msg)
    {
        body.transform.localPosition = msg.PlayerSpawnPoint + new Vector3(0, 0, body.transform.localPosition.z);
    }
}
