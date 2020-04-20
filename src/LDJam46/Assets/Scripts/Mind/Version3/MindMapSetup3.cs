
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
    [SerializeField] private DaySpawnRules[] days;
    [SerializeField] private CurrentGameState gameState;

    private void OnEnable()
    {
        foreach (Transform child in mapParent.transform)
            Destroy(child.gameObject);
        var map = Instantiate(maps.Random(), mapParent.transform);
        
        Debug.Log($"Number of Possible Character Start Locations {map.CharacterSpawningPoints.Length}");
        Message.Publish(new MapGenerated(map.CharacterSpawningPoints.Any() ? map.CharacterSpawningPoints.Random().position : defaultSpawn));
        var rules = GetRules();
        itemSpawner.Spawn(map.ItemSpawnPoints.Select(x => x.position).ToList(), rules.items);
        foreach (var demon in rules.demons)
            if (demon.SpawnChance > Rng.Dbl())
                Message.Publish(new ActivateDemon(demon.Demon));
    }

    private BlackoutSpawnRules GetRules()
    {
        var day = days.Length >= gameState.GameState.DayNumber ? days[gameState.GameState.DayNumber - 1] : days.Last();
        return day.blackouts.Length > gameState.GameState.BlackoutsToday ? day.blackouts[gameState.GameState.BlackoutsToday] : day.blackouts.Last();
    }
}
