using Cinemachine;
using UnityEngine;

public class SetCameraToFollowMainCharacter : OnMessage<WorldSwapFinished>
{
    [SerializeField] private CurrentPlayerCharacter character;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    void Start() => virtualCamera.Follow = character.PlayerCharacter.transform;
    protected override void Execute(WorldSwapFinished msg)
    {
        virtualCamera.Follow = character.PlayerCharacter.transform;
    }
}
