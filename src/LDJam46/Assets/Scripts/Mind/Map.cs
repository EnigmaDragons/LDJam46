using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Mind
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private Transform groundParent;
        [SerializeField] private SpriteRenderer[] grounds;
        [SerializeField] private GameObject player;
        [SerializeField] private Vector2 distanceToGeneration;
        [SerializeField] private Vector2 groundSize;

        private readonly HashSet<Vector2> _generatedGround = new HashSet<Vector2>();

        private void Update()
        {
            for (var x = (int)Math.Floor((player.transform.localPosition.x - distanceToGeneration.x) / groundSize.x) * groundSize.x; 
                    x <= Math.Ceiling((player.transform.localPosition.x + distanceToGeneration.x) / groundSize.x) * groundSize.x; 
                    x += groundSize.x)
                for (var y = (int)Math.Floor((player.transform.localPosition.y - distanceToGeneration.y) / groundSize.y) * groundSize.y;
                        y <= Math.Ceiling((player.transform.localPosition.y + distanceToGeneration.y) / groundSize.y) * groundSize.y;
                        y += groundSize.y)
                    if (!_generatedGround.Contains(new Vector2(x, y)))
                    {
                        var sprite = Instantiate(grounds.Random(), new Vector3(x, y, 0), Quaternion.identity, groundParent);
                        sprite.sortingOrder = (int)Math.Round(y);
                        _generatedGround.Add(new Vector2(x, y));
                    }
        }
    }
}
