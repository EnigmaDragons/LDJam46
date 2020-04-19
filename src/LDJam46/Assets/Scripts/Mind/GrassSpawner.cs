using UnityEngine;

public class GrassSpawner : MonoBehaviour, ISpawner
{
    [SerializeField, Range(0, 100)] private float density;
    [SerializeField] private GameObject[] foliage;
    
    public void Spawn(Vector2Int size)
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
        
        var iterator = new TwoDimensionalIterator(size.x, size.y);
        iterator.ForEach(xy =>
        {
            if (Rng.Dbl() * 100 < density)
            {
                var o = foliage.Random();
                Instantiate(o, new Vector3(xy.Item1, xy.Item2, 0), o.transform.localRotation, transform);
            }
        });
    }
}
