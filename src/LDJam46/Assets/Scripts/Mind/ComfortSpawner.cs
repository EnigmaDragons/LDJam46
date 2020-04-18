using UnityEngine;

public class ComfortSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private MapGeneratorObject[] objects;

    public void Spawn(Vector2Int size)
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
        
        var iterator = new TwoDimensionalIterator(size.x, size.y);
        iterator.ForEach(xy =>
        {
            foreach (var o in objects)
                if (Rng.Dbl() * 100 < o.PercentChance)
                {
                    Instantiate(o.Object, new Vector3(xy.Item1, xy.Item2, 0), o.Object.transform.localRotation, transform);
                    break;
                }
        });
    }
}
