
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner3 : MonoBehaviour
{
    [SerializeField] private ItemSpawnRule[] rules;
    
    public void Spawn(List<Vector3> possibleItemLocations)
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
        
        var queue = possibleItemLocations.ToArray().Shuffled();
        var index = 0;
        foreach (var rule in rules)
        {
            for (var n = 0; n < rule.NumberToSpawn; n++)
            {
                if (index < queue.Length)
                {
                    Instantiate(rule.Object, queue[index], rule.Object.transform.localRotation, transform);
                    index++;
                }
            }

        }
    }
}
