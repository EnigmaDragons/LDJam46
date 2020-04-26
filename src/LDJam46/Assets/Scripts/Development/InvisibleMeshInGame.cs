using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public sealed class InvisibleMeshInGame : MonoBehaviour
{
    void Awake() => GetComponent<MeshRenderer>().enabled = false;
}
