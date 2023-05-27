using DG.Tweening;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class BirdController : MonoBehaviour
{
    
    public float ScaredDistance;
    public AnimationCurve FleeingCurve;
    public float FlyingSpeed;
    public float FlyingLength;

    private Tween _flyTween;
    
    private enum BirdState
    {
        OnGround,
        Fleeing,
    }

    private BirdState State = BirdState.OnGround;
    private Transform _playerTransform;
    private Vector3 _playerPosition => _playerTransform.position;
    private Vector3 _groundPosition;

    private void Start()
    {
        GameManager.OnNewCharacterInstance += GetPlayerTransform;
        _groundPosition = transform.position;
    }

    private void Update()
    {
        if (_playerTransform == null) return;

        if (State == BirdState.OnGround)
        {
            if (PlayerInScaredDistance())
            {
                FleeFromPosition(_playerPosition);
            }
        }
        else if (State == BirdState.Fleeing)
        {

        }
    }

    #region Initialization
    private void GetPlayerTransform(GameObject character)
    {
        _playerTransform = character.transform;
    }
    #endregion

    #region PlayerDistances
    private float DistanceToPlayer()
    {
        return (_groundPosition - _playerPosition).magnitude;
    }

    private bool PlayerInScaredDistance()
    {
        return DistanceToPlayer() < ScaredDistance;
    }
    #endregion

    #region Flying
    private void FleeFromPosition(Vector3 position)
    {
        Vector3 targetPos = transform.position + FlyingLength * FleeingDirection(position);
        _flyTween = transform.DOMove(targetPos, FlyingLength / FlyingSpeed).SetEase(FleeingCurve);
        _flyTween.onStepComplete += DestroySelf;
        State = BirdState.Fleeing;
    }

    private Vector3 FleeingDirection(Vector3 fleeingPosition)
    {
        Vector3 direction = (transform.position - fleeingPosition).normalized;
        direction.y = Mathf.Abs(direction.y) + 0.7f;

        return direction.normalized;
    }
    #endregion

    #region Destruction
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
    #endregion
}
