
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MindMapSetup3 : OnMessage<RecordCharacterSpawnPoint>
{
    [SerializeField] private CurrentPlayerCharacter character;
    [SerializeField] private Vector3 defaultSpawn;
    [SerializeField] private GameObject[] maps;

    private readonly List<Vector3> _characterSpawnPoints = new List<Vector3>();
    
    protected override void OnEnable()
    {
        base.OnEnable();
        foreach (Transform child in transform)
            Destroy(child.gameObject);
        
        _characterSpawnPoints.Clear();

        Instantiate(maps.Random(), transform);
        character.PlayerCharacter.transform.position = _characterSpawnPoints.Any() ?  _characterSpawnPoints.Random() : defaultSpawn;
    }
    
    protected override void Execute(RecordCharacterSpawnPoint msg)
    {
        _characterSpawnPoints.Add(msg.Location);
    }
}
