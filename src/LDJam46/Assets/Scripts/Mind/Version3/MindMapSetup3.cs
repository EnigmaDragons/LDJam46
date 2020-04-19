
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MindMapSetup3 : OnMessage<RecordCharacterSpawnPoint, RecordItemSpawnPoint>
{
    [SerializeField] private CurrentPlayerCharacter character;
    [SerializeField] private Vector3 defaultSpawn;
    [SerializeField] private GameObject[] maps;
    [SerializeField] private ItemSpawner3 itemSpawner;
    [SerializeField] private GameObject mapParent;
    
    private readonly List<Vector3> _characterSpawnPoints = new List<Vector3>();
    private readonly List<Vector3> _itemSpawnPoints = new List<Vector3>();
    
    protected override void OnEnable()
    {
        base.OnEnable();
        _characterSpawnPoints.Clear();
        
        foreach (Transform child in mapParent.transform)
            Destroy(child.gameObject);
        Instantiate(maps.Random(), mapParent.transform);
        
        character.PlayerCharacter.transform.position = _characterSpawnPoints.Any() ?  _characterSpawnPoints.Random() : defaultSpawn;
        itemSpawner.Spawn(_itemSpawnPoints);
    }
    
    protected override void Execute(RecordCharacterSpawnPoint msg) => _characterSpawnPoints.Add(msg.Location);

    protected override void Execute(RecordItemSpawnPoint msg) => _itemSpawnPoints.Add(msg.Location);
}
