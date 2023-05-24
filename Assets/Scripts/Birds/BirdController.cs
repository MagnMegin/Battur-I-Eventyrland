using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BirdController : MonoBehaviour
{
    
    public float ScaredDistance;
    public float SafeDistance;
    public AnimationCurve FleeingCurve;
    public AnimationCurve ReturningCurve;
    public float FlyingSpeed;
    public float FlyingLength;
    
    private enum BirdState
    {
        OnGround,
        Fleeing,
        Soaring,
        Returning,
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
                FlyAwayFromPosition(_playerPosition);
            }
        }
        else if (State == BirdState.Soaring)
        {
            if (PlayerOutsideSafeDistance())
            {
                ReturnToGroundPosition();
            }
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

    private bool PlayerOutsideSafeDistance()
    {
        return DistanceToPlayer() > SafeDistance;
    }
    #endregion

    #region Fleeing
    private void FlyAwayFromPosition(Vector3 position)
    {
        State = BirdState.Fleeing;
        StartCoroutine(FleeingSequence(position));
    }

    private IEnumerator FleeingSequence(Vector3 position)
    {
        Func<float, Vector3> flyingPos = distance =>
        {
            return _groundPosition + distance * (_groundPosition - position).normalized;
        };
        float timePassed = 0f;
        float distanceTraveled = 0f;

        while (distanceTraveled < FlyingLength)
        {
            distanceTraveled = FlyingLength * FleeingCurve.Evaluate(timePassed * FlyingSpeed / FlyingLength);
            transform.position = flyingPos(distanceTraveled);
            timePassed += Time.deltaTime;
            yield return null;
        }

        State = BirdState.Soaring;
    }
    #endregion

    #region Returning
    private void ReturnToGroundPosition()
    {
        State = BirdState.Returning;
        StartCoroutine(ReturnSequence());
    }

    private IEnumerator ReturnSequence()
    {
        Vector3 initialPos = transform.position;
        Func<float, Vector3> flyingPos = distance =>
        {
            return transform.position + distance * (_groundPosition - initialPos).normalized;
        };
        float timePassed = 0f;
        float distanceTraveled = 0f;

        while (distanceTraveled < FlyingLength)
        {
            distanceTraveled = FlyingLength * FleeingCurve.Evaluate(timePassed * FlyingSpeed / FlyingLength);
            transform.position = flyingPos(distanceTraveled);
            timePassed += Time.deltaTime;
            yield return null;
        }
        State = BirdState.OnGround;
    }
    #endregion
}
