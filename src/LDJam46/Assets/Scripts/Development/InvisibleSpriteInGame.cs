using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class InvisibleSpriteInGame : MonoBehaviour
{
    void Awake() => GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
}
