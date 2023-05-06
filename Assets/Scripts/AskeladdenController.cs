using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskeladdenController : MonoBehaviour
{
    public float MoveSpeed;
    
    public bool IsActive { get; private set; }

    private Vector3 _moveDirection;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveDirection = InputManager.GetMovement();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveDirection * MoveSpeed;
    }
}
