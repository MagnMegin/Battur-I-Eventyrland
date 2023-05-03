using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveSnailController : MonoBehaviour
{
    public float MoveSpeed;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 direction = (Vector3.right * x) + (Vector3.forward * y);
        transform.position += direction * Time.deltaTime * MoveSpeed;
    }
}
