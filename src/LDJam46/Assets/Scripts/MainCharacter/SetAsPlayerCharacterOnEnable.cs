using UnityEngine;

public class SetAsPlayerCharacterOnEnable : MonoBehaviour
{
    [SerializeField] private CurrentPlayerCharacter character;

    void OnEnable() => character.PlayerCharacter = gameObject;
}
