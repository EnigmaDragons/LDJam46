using Cinemachine;
using UnityEngine;

public class SetCameraToFollowMainCharacter : MonoBehaviour
{
    [SerializeField] private CurrentPlayerCharacter character;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    void Start() => virtualCamera.Follow = character.PlayerCharacter.transform;
}
