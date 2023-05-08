using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSnailController : MonoBehaviour
{
    public float MoveSpeed;

    private Vector3 _moveDirection;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        _moveDirection = ((Vector3.right * x) + (Vector3.up * y)).normalized;
    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveDirection * MoveSpeed;
    }
}
