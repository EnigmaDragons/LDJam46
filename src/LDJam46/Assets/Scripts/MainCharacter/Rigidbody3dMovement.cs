using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rigidbody3dMovement : MonoBehaviour {
    [SerializeField] private float moveLimiter = 0.7f;
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private CurrentGameState state;

    private Rigidbody _body;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private float _horizontal;
    private float _vertical;
    private float _idleTimer;

    private bool _isThinking = false;

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal"); 
        _vertical = Input.GetAxisRaw("Vertical");

        // if Idle for (5s) transition toTHINKING
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle-MAIN")) {            
            if (_isThinking) {
                _isThinking = false;
                _animator.ResetTrigger("toTHINKING");
            }
            if (!_isThinking) {
                _idleTimer = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            }            
        }
        if (_idleTimer > 5 && !_isThinking) {
            _idleTimer = 0;
            _isThinking = true;            
            _animator.ResetTrigger("Exit");
            _animator.SetTrigger("toTHINKING");
        }
    }

    void FixedUpdate()
    {
        if (state.GameState.isInDialogue == false) {
            if (Math.Abs(_horizontal) > 0.001f && Math.Abs(_vertical) > 0.001f) {
                _horizontal *= moveLimiter;
                _vertical *= moveLimiter;
            }

            _body.velocity = new Vector2(_horizontal * moveSpeed, _vertical * moveSpeed);
            
            // if velocity > 0 flip X (right)
            if (_body.velocity.x > 0) {
                _sprite.flipX = true;
            } else if (_body.velocity.x < 0) {
                _sprite.flipX = false;
            }            

            // transition from idle to walk

            if (_body.velocity.x < 0 || _body.velocity.x > 0 || _body.velocity.y < 0 || _body.velocity.y > 0) {
                _animator.SetTrigger("toWALK");                
            } else if (_body.velocity.x == 0 || _body.velocity.y == 0) {
                _animator.ResetTrigger("toWALK");
                _animator.SetTrigger("Exit");
            }            
        } else {
            _body.velocity = Vector2.zero;
        }
    }
}
