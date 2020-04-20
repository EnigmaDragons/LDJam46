
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MindMapSetup3 : MonoBehaviour
{
    [SerializeField] private CurrentPlayerCharacter character;
    [SerializeField] private Vector3 defaultSpawn;
    [SerializeField] private MapSpawnPoints[] maps;
    [SerializeField] private ItemSpawner3 itemSpawner;
    [SerializeField] private GameObject mapParent;

    private void OnEnable()
    {
        foreach (Transform child in mapParent.transform)
            Destroy(child.gameObject);
        var map = Instantiate(maps.Random(), mapParent.transform);
        
        Debug.Log($"Number of Possible Character Start Locations {map.CharacterSpawningPoints.Length}");
        Message.Publish(new MapGenerated(map.CharacterSpawningPoints.Any() ? map.CharacterSpawningPoints.Random().position : defaultSpawn));
        itemSpawner.Spawn(map.ItemSpawnPoints.Select(x => x.position).ToList());
    }
}
