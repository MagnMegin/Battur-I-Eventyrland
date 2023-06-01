using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskeladdenController : MonoBehaviour
{
    public float MoveSpeed;
    public Animator Anim;
    public SpriteRenderer Renderer;
    
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
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveDirection * MoveSpeed;
    }

    private void UpdateAnimation()
    {
        if (_moveDirection == Vector3.zero)
        {
            Anim.SetBool("IsMoving", false);
            return;
        }

        Anim.SetBool("IsMoving", true);
        Anim.SetFloat("X", _moveDirection.x);
        Anim.SetFloat("Y", _moveDirection.y);

        if(_moveDirection.x < -0.1)
        {
            Renderer.flipX = true;
        }
        else if (_moveDirection.x > 0.1)
        {
            Renderer.flipX = false; 
        }
    }
    #endregion
}
