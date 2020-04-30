using UnityEngine;

public sealed class OnEnableMoveMainCharacterTo : MonoBehaviour
{
    [SerializeField] private CurrentPlayerCharacter character;

    private void OnEnable() => character.PlayerCharacter.transform.localPosition = transform.localPosition;
}
