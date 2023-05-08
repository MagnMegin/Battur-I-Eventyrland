using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskeladdenController : MonoBehaviour
{
    public float MoveSpeed;
    
    private Vector3 _moveDirection;
    private Rigidbody2D _rb;

    #region Unity Messages
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
    #endregion
}
