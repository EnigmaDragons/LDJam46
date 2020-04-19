using System;
using Assets.Scripts.Demons;
using UnityEngine;
using UnityEngine.AI;

public class ParanoiaDemon : MonoBehaviour
{
    [SerializeField] private CurrentPlayerCharacter _player;
    [SerializeField] private DemonState _demonState;
    [SerializeField] private float _freezeAngle;
    [SerializeField] private float _secondsPerPercent;
    [SerializeField] private float _accelrationMultipier;
    [SerializeField] private float _minSpeed;

    private float _speed;
    private Vector2 _playerLookDirection;

    private void OnEnable() => _demonState.Activate();

    private void Update()
    {
        if (_demonState.IsActive == false)
            gameObject.SetActive(false);
        if (_player.PlayerCharacter.GetComponentInChildren<SpriteRenderer>().flipX)
            _playerLookDirection = new Vector2(1, 0);
        else
            _playerLookDirection = new Vector2(-1, 0);
        var angle = Vector2.Angle(_playerLookDirection, transform.position - _player.PlayerCharacter.transform.position);
        if (angle < _freezeAngle)
        {
            _speed = 0;
        }
        else
        {
            _demonState.Increment(Time.deltaTime / _secondsPerPercent / 100);
            _speed = Math.Max(_speed, _minSpeed);
            _speed += _demonState.ProgressPercent * _accelrationMultipier;
            transform.position += Vector3.ClampMagnitude((_player.PlayerCharacter.GetComponentInChildren<Collider>().transform.position - transform.position).normalized, 1) * _speed * Time.deltaTime;
        }
    }
}