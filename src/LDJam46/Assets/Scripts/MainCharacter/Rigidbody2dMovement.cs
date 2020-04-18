using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rigidbody2dMovement : MonoBehaviour
{
    [SerializeField] private float moveLimiter = 0.7f;
    [SerializeField] private float moveSpeed = 20f;
    private Rigidbody2D _body;

    private float _horizontal;
    private float _vertical;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal"); 
        _vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (Math.Abs(_horizontal) > 0.001f && Math.Abs(_vertical) > 0.001f)
        {
            _horizontal *= moveLimiter;
            _vertical *= moveLimiter;
        } 

        _body.velocity = new Vector2(_horizontal * moveSpeed, _vertical * moveSpeed);
    }
}
