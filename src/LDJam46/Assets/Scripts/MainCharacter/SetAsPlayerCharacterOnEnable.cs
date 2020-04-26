using UnityEngine;

public class SetAsPlayerCharacterOnEnable : MonoBehaviour
{
    [SerializeField] private CurrentPlayerCharacter character;

    void Awake() => character.PlayerCharacter = gameObject;
    void OnEnable() => character.PlayerCharacter = gameObject;
}
