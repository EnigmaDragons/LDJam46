using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Mind
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private Transform groundParent;
        [SerializeField] private Transform objectParent;
        [SerializeField] private SpriteRenderer[] grounds;
        [SerializeField] private CurrentPlayerCharacter player;
        [SerializeField] private Vector2 distanceToGeneration;
        [SerializeField] private Vector2 groundSize;
        [SerializeField, Header("This order matters for spawn priority")] private MapObject[] mapObjects;
        [SerializeField] private int spawnRetries;

        private readonly Dictionary<Vector2, List<KeyValuePair<Vector2, float>>> _generatedGround = new Dictionary<Vector2, List<KeyValuePair<Vector2, float>>>();

        private void Update()
        {
            var pos = player.PlayerCharacter.transform.localPosition;
            for (var x = (int)Math.Floor((pos.x - distanceToGeneration.x) / groundSize.x) * groundSize.x; 
                    x <= Math.Ceiling((pos.x + distanceToGeneration.x) / groundSize.x) * groundSize.x; 
                    x += groundSize.x)
                for (var y = (int)Math.Floor((pos.y - distanceToGeneration.y) / groundSize.y) * groundSize.y;
                        y <= Math.Ceiling((pos.y + distanceToGeneration.y) / groundSize.y) * groundSize.y;
                        y += groundSize.y)
                    if (!_generatedGround.ContainsKey(new Vector2(x, y)))
                        SpawnMapTile(x, y);
        }

        private void SpawnMapTile(float x, float y)
        {
            var sprite = Instantiate(grounds.Random(), new Vector3(x, y, 0), Quaternion.identity, groundParent);
            sprite.sortingOrder = (int)Math.Round(y);
            var takenSpots = new List<KeyValuePair<Vector2, float>>();
            var adjecentTakenSpots = new List<KeyValuePair<Vector2, float>>();
            if (_generatedGround.ContainsKey(new Vector2(x - groundSize.x, y)))
                adjecentTakenSpots.AddRange(_generatedGround[new Vector2(x - groundSize.x, y)]);
            if (_generatedGround.ContainsKey(new Vector2(x + groundSize.x, y)))
                adjecentTakenSpots.AddRange(_generatedGround[new Vector2(x + groundSize.x, y)]);
            if (_generatedGround.ContainsKey(new Vector2(x, y - groundSize.y)))
                adjecentTakenSpots.AddRange(_generatedGround[new Vector2(x, y - groundSize.y)]);
            if (_generatedGround.ContainsKey(new Vector2(x, y + groundSize.y)))
                adjecentTakenSpots.AddRange(_generatedGround[new Vector2(x, y + groundSize.y)]);
            foreach (var mapObject in mapObjects)
            {
                if (mapObject.PercentChance / 100 > Rng.Dbl())
                {
                    var spotToSpawn = new Vector2((float)(x + Rng.Dbl() * groundSize.x), (float)(y + Rng.Dbl() * groundSize.y));
                    var succeededSpawning = false;
                    for (int i = 0; i <= spawnRetries; i++)
                    {
                        if (takenSpots.Concat(adjecentTakenSpots).Any(spot =>
                        {
                            var distance = Vector3.Distance(spot.Key, spotToSpawn);
                            return distance < spot.Value || distance < mapObject.PreventSpawnZone;
                        }))
                        {
                            spotToSpawn = new Vector2((float)(x + Rng.Dbl() * groundSize.x), (float)(y + Rng.Dbl() * groundSize.y));
                        }
                        else
                        {
                            var instatiatedObj = Instantiate(mapObject.Object, spotToSpawn, Quaternion.identity, objectParent);
                            instatiatedObj.sortingOrder = (int)Math.Round(spotToSpawn.y * 100);
                            takenSpots.Add(new KeyValuePair<Vector2, float>(spotToSpawn, mapObject.PreventSpawnZone));
                            succeededSpawning = true;
                        }
                    }
                    if (!succeededSpawning)
                        Debug.Log($"Failed to find a spot for {mapObject.Object.name}");
                }
            }
            _generatedGround[new Vector2(x, y)] = takenSpots;
        }
    }
}
