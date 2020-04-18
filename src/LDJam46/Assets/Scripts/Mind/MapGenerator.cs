using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private GroundSpawner ground;

    public void OnEnable()
    {
        var sizeV = new Vector2Int(size, size);
        ground.Spawn(sizeV);
    }
}
