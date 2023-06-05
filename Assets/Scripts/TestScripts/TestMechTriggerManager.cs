using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestMechTriggerManager : MonoBehaviour
{
    public GameObject CollectedPlank1;
    public GameObject CollectedPlank2;
    public GameObject CollectedPlank3;
    public GameObject TestPlank3;
    public GameObject skipUtenMech;
    public GameObject skipKlarTilBro;
    public GameObject BoatFixer1;
    public GameObject BoatFixer2;
    public GameObject RabbitScared;
    public GameObject RabbitAfterCombat;
    public GameObject BossCharacter;

    private bool _mechShipHasBeenActivated;
    private bool _twoPlanksActive;
    private bool _bossDefeated;
    private bool _bossFightActivated;
    private bool _winCondition;
    
    public bool _talkedToRabbit;

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
        if (_talkedToRabbit == true)
        {
            BossCharacter.SetActive(true);
            _bossFightActivated = true;
            _talkedToRabbit = false;

        }
        if (BossCharacter.activeInHierarchy == false && !_bossDefeated && _bossFightActivated)
        {
            RabbitAfterCombat.SetActive(true);
            TestPlank3.SetActive(true);
            RabbitScared.SetActive(false);
            _bossDefeated = true;
        }
        if (CollectedPlank3.activeInHierarchy == true && !_winCondition)
        {
            _winCondition = true;
        }
        if (_winCondition == true)
        {
            SceneManager.LoadSceneAsync("LevelWon");
        }
    }


}
