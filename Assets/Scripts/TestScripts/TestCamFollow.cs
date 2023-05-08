using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamFollow : MonoBehaviour
{
    public Transform FollowTransform;
    private Vector3 _playerToCam;

    private void Start()
    {
        _playerToCam = transform.position - FollowTransform.position;
    }

    void LateUpdate()
    {
        transform.position = FollowTransform.position + _playerToCam;
    }
}
