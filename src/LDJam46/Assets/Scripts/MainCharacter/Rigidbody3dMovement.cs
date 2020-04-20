using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Rigidbody3dMovement : MonoBehaviour {
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private CurrentGameState state;
    [SerializeField] private FootstepsSounds footsteps;
    [SerializeField] private float sprintSpeed = 40f;
    [SerializeField] private float maxSprintTime;
    [SerializeField] private float sprintRegenPerSecond;
    private Rigidbody _body;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private float _horizontal;
    private float _vertical;
    private float _idleTimer;
    private float _currentSprintTime;

    private bool _isThinking = false;

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _currentSprintTime = maxSprintTime;
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
            Debug.Log("Move - Thinking");
        }
    }

    void FixedUpdate()
    {
        if (!state.GameState.isInDialogue) {
            if (Input.GetButton("Sprint"))
            {
                if (_currentSprintTime > 0)
                {
                    _body.velocity = Vector2.ClampMagnitude(new Vector2(_horizontal, _vertical).normalized, 1) * sprintSpeed;
                    _currentSprintTime = Math.Max(0, _currentSprintTime -= Time.fixedDeltaTime);
                    Message.Publish(new SprintChanged(_currentSprintTime / maxSprintTime));
                    Run();
                }
                else
                {
                    _body.velocity = Vector2.ClampMagnitude(new Vector2(_horizontal, _vertical).normalized, 1) * moveSpeed;
                    Walk();
                }
            }
            else
            {
                _body.velocity = Vector2.ClampMagnitude(new Vector2(_horizontal, _vertical).normalized, 1) * moveSpeed;
                _currentSprintTime = Math.Min(maxSprintTime, _currentSprintTime + Time.fixedDeltaTime * sprintRegenPerSecond);
                Message.Publish(new SprintChanged(_currentSprintTime / maxSprintTime));
                Walk();
            }
            
            
            // if velocity > 0 flip X (right)
            if (_body.velocity.x > 0) {
                _sprite.flipX = true;
            } else if (_body.velocity.x < 0) {
                _sprite.flipX = false;
            }
        } else {
            _body.velocity = Vector2.zero;
            Idle();
        }
    }

    private bool IsStopped() => _body.velocity.x == 0 && _body.velocity.y == 0;

    private void Idle()
    {
        _animator.ResetTrigger("toRUN");
        _animator.ResetTrigger("toWALK");
        footsteps.Stop();
        _animator.SetTrigger("Exit");
    }

    private void Walk()
    {
        if (IsStopped())
            Idle();
        else
        {
            _animator.ResetTrigger("toTHINKING");
            _animator.ResetTrigger("Exit");
            _animator.ResetTrigger("toRUN");
            _animator.SetTrigger("toWALK");
            footsteps.StartWalking();
        }
    }

    private void Run()
    {
        if (IsStopped())
            Idle();
        else
        {
            _animator.ResetTrigger("toTHINKING");
            _animator.ResetTrigger("Exit");
            _animator.ResetTrigger("toWALK");
            _animator.SetTrigger("toRUN");
            footsteps.StartRunning();
        }
    }
}
