using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMechTriggerManager : MonoBehaviour
{
    public GameObject CollectedPlank1;
    public GameObject CollectedPlank2;
    public GameObject CollectedPlank3;
    public GameObject skipUtenMech;
    public GameObject skipKlarTilBro;
    private bool _mechShipHasBeenActivated;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (CollectedPlank1.activeInHierarchy && CollectedPlank2.activeInHierarchy && !_mechShipHasBeenActivated)
        {
            skipKlarTilBro.SetActive(true);
            skipUtenMech.SetActive(false);
            _mechShipHasBeenActivated = true;
        }
    }


}
