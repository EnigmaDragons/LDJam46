using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawner3 : MonoBehaviour
{
    public void Spawn(List<Vector3> possibleItemLocations, ItemSpawnRule[] itemSpawnRules)
    {
        //Debug.Log($"Number of Possible Item Locations {possibleItemLocations.Count}");
        foreach (Transform child in transform)
            Destroy(child.gameObject);
        
        var queue = possibleItemLocations.ToArray().Shuffled();
        var index = 0;
        foreach (var rule in itemSpawnRules)
        {
            //Debug.Log($"Spawning {rule.NumberToSpawn} {rule.Object.name}(s)");
            for (var n = 0; n < rule.NumberToSpawn; n++)
            {
                if (index < queue.Length)
                {
                    Instantiate(rule.Object, queue[index], rule.Object.transform.localRotation, transform);
                    //Debug.Log($"Spawned {rule.Object.name} #{n}");
                    index++;
                }
            }

        }
    }
}
