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
    public GameObject BoatFixer1;
    public GameObject BoatFixer2;
    private bool _mechShipHasBeenActivated;
    private bool _twoPlanksActive;
    
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
        if (skipKlarTilBro.activeInHierarchy && !_twoPlanksActive)
        {
            BoatFixer2.SetActive(true);
            BoatFixer1.SetActive(false);
            _twoPlanksActive = true;
        }
    }


}
