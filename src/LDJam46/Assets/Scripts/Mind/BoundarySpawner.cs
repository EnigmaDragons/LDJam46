using System;
using System.Linq;
using UnityEngine;

public class BoundarySpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private GameObject[] boundaryTiles;
    [SerializeField] private int boundarySize;
    [SerializeField] private int boundaryTileUnitWidth;
    
    public void Spawn(Vector2Int size)
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
        
        var iterator = new TwoDimensionalIterator(boundarySize * 2 + size.x, boundarySize * 2 + size.y);
        iterator
            // Offset
            .Select(xy => new Tuple<int, int>(
                xy.Item1 - boundarySize - boundaryTileUnitWidth / 2, 
                xy.Item2 - boundarySize - boundaryTileUnitWidth / 2))
            .ForEach(xy =>
            {
                var x = xy.Item1;
                var y = xy.Item2;
                if (x % boundaryTileUnitWidth == 0 && y % boundaryTileUnitWidth == 0)
                {
                    if ((x < 0 || x >= size.x) || (y < 0 || y >= size.y))
                    {
                        var tile = boundaryTiles[Rng.Int(boundaryTiles.Length)];
                        Instantiate(tile, new Vector3(x, y), tile.transform.localRotation, transform);
                    }
                } 
            });
    }
}
