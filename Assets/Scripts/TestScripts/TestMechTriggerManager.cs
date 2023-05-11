using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMechTriggerManager : MonoBehaviour
{
    public GameObject CollectedPlank1;
    public GameObject CollectedPlank2;
    public GameObject CollectedPlank3;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (CollectedPlank1.activeInHierarchy && CollectedPlank2.activeInHierarchy)
        {
            Debug.Log("2 planks active");
        }
    }
}
