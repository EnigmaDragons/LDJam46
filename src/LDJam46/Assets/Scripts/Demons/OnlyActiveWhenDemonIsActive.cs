
using UnityEngine;

public class OnlyActiveWhenDemonIsActive : MonoBehaviour
{
    [SerializeField] private DemonState demon;
    [SerializeField] private GameObject target;

    private void Update()
    {
        target.SetActive(demon.IsActive);
    }
}
