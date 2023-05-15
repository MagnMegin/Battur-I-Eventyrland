using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, PLAYERINTERACT, ENEMYTURN, ENEMYINTERACT, WON, LOST }
public class CombatSystem : MonoBehaviour
{

    public bool _player1TurnDone = false;
    public bool _player2TurnDone = false;

    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public GameObject enemyPrefab;

    public GameObject player1Buttons;
    public GameObject player2Buttons;

    public Transform player1BattleSpot;
    public Transform player2BattleSpot;
    public Transform enemyBattleSpot;

    public Unit player1Unit;
    public Unit player2Unit;
    public Unit enemyUnit;

    public TextMeshProUGUI dialogueText;
    public BattleHUD player1HUD;
    public BattleHUD player2HUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    private void Start()
    {
        state = BattleState.START;

        GameObject player1GO = Instantiate(player1Prefab, player1BattleSpot);
        player1Unit = player1GO.GetComponent<Unit>();

        GameObject player2GO = Instantiate(player2Prefab, player2BattleSpot);
        player2Unit = player2GO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleSpot);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = enemyUnit.unitName + " skaper trøbbel for deg!";

        player1HUD.SetHUD(player1Unit);
        player2HUD.SetHUD(player2Unit);
        enemyHUD.SetHUD(enemyUnit);

        StartCoroutine(SetupBattle());

    }


    IEnumerator SetupBattle()
    {

        yield return new WaitForSeconds(3f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        Debug.Log("PlayerTurn");
        dialogueText.text = "Velg en handling";

        player1Buttons.SetActive(true);
        player2Buttons.SetActive(true);

    }





    public void DamageEnemy()
    {
        
        Unit U = gameObject.GetComponent<Unit>();
        enemyHUD.UpdateHP(enemyUnit);

    }
























}
