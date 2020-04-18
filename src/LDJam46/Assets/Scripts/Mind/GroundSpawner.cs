using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject floor;
    
    public void Spawn(Vector2Int size)
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
        
        var iterator = new TwoDimensionalIterator(size.x, size.y);
        iterator.ForEach(xy => Instantiate(floor, new Vector3(xy.Item1, xy.Item2, 0), Quaternion.identity, transform));
    }
}
