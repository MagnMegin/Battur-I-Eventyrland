using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, PLAYERINTERACT, ENEMYTURN, ENEMYINTERACT, WON, LOST }
public class CombatSystem : MonoBehaviour
{

    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public GameObject enemyPrefab;

    public GameObject player1ButtonsPrefab;
    public GameObject player2ButtonsPrefab;

    public Transform player1ButtonParent;
    public Transform player2ButtonParent;

    public Transform player1BattleSpot;
    public Transform player2BattleSpot;
    public Transform enemyBattleSpot;

    Unit player1Unit;
    Unit player2Unit;
    Unit enemyUnit;

    public TextMeshProUGUI dialogueText;
    public BattleHUD player1HUD;
    public BattleHUD player2HUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    private void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());

    }


    IEnumerator SetupBattle()
    {
        GameObject player1GO = Instantiate(player1Prefab, player1BattleSpot);
        player1Unit = player1GO.GetComponent<Unit>(); 
        
        GameObject player2GO = Instantiate(player2Prefab, player2BattleSpot);
        player2Unit = player2GO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleSpot);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = enemyUnit.unitName + " skaper trøbbel for deg!";

        player1HUD.SetHUD(player1Unit);
        player2HUD.SetHUD(player2Unit);
        enemyHUD.SetHUD(player1Unit);

        yield return new WaitForSeconds(3f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        Debug.Log("PlayerTurn");
        dialogueText.text = "Velg en handling";
        GameObject AskButtons = Instantiate(player1ButtonsPrefab, player1ButtonParent);
        GameObject KompanjongButtons = Instantiate(player2ButtonsPrefab, player2ButtonParent);

       
    }

}
