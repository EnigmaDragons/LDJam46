using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private GroundSpawner ground;
    [SerializeField] private TreeSpawner trees;
    [SerializeField] private ComfortSpawner comfort;
    [SerializeField] private BoundarySpawner boundary;

    public void OnEnable()
    {
        var sizeV = new Vector2Int(size, size);
        boundary.Spawn(sizeV);
        ground.Spawn(sizeV);
        trees.Spawn(sizeV);
        comfort.Spawn(sizeV);
    }
}
