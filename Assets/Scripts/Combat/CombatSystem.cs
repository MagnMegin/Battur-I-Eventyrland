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
    public bool _enemyTurnDone = false;

    public BasicTrollCombat trollCombatScript;

    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public GameObject enemyPrefab;

    public GameObject player1Buttons;
    public GameObject player2Buttons;
    public GameObject healPick;

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


    void Awake()
    {
        GameObject player1GO = Instantiate(player1Prefab, player1BattleSpot);
        player1Unit = player1GO.GetComponent<Unit>();
        ButtonAcessPanel.Player1 = player1GO;

        GameObject player2GO = Instantiate(player2Prefab, player2BattleSpot);
        player2Unit = player2GO.GetComponent<Unit>();
        ButtonAcessPanel.Player2 = player2GO;

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleSpot);
        enemyUnit = enemyGO.GetComponent<Unit>();
    }


    private void Start()
    {
        state = BattleState.START;

        dialogueText.text = enemyUnit.unitName + " skaper trøbbel for deg!";

        player1HUD.SetHUD(player1Unit);
        player2HUD.SetHUD(player2Unit);
        enemyHUD.SetHUD(enemyUnit);

        StartCoroutine(PlayerTurn());

        trollCombatScript = FindObjectOfType<BasicTrollCombat>();

    }

    IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(3f);

        Debug.Log("PlayerTurn");
        dialogueText.text = "Velg en handling";

        player1Unit.currentPoints = player1Unit.currentPoints + 2;
        if (player1Unit.currentPoints > player1Unit.maxPoints)
        {
            player1Unit.currentPoints = player1Unit.maxPoints;
        }

        player2Unit.currentPoints = player2Unit.currentPoints + 2;
        if (player2Unit.currentPoints > player2Unit.maxPoints)
        {
            player2Unit.currentPoints = player2Unit.maxPoints;
        }

        state = BattleState.PLAYERTURN;

        player1Buttons.SetActive(true);
        player2Buttons.SetActive(true);
        _player1TurnDone = false;
        _player2TurnDone = false;
        _enemyTurnDone = false;
    }





    public IEnumerator DamageUpdate()
    {
        Unit U = gameObject.GetComponent<Unit>();
        enemyHUD.UpdateHP(enemyUnit);
        player1HUD.UpdateHP(player1Unit);
        player2HUD.UpdateHP(player2Unit);

        yield return new WaitForSeconds(3f);

        if (_player1TurnDone == false)
        {
            player1Buttons.SetActive(true);
        }
        else if (_player2TurnDone == false)
        {
            player2Buttons.SetActive(true);
        }
        else
        {
            if (_enemyTurnDone == true)
            {
                StartCoroutine (PlayerTurn());
            }
            else
            {
                state = BattleState.ENEMYTURN;
                BasicTrollCombat TC = FindObjectOfType<BasicTrollCombat>();
                StartCoroutine(TC.EnemyTurnStart());
            }
        }

    }

    public IEnumerator HealPlayers()
    {
        yield return new WaitForSeconds(3f);

        Unit U = gameObject.GetComponent<Unit>();
        player1HUD.UpdateHP(player1Unit);
        player2HUD.UpdateHP(player2Unit);

        if (_player1TurnDone == false)
        {
            player1Buttons.SetActive(true);
        }
        else if (_player2TurnDone == false)
        {
            player2Buttons.SetActive(true);
        }
        else
        {
            state = BattleState.ENEMYTURN;

            BasicTrollCombat TC = FindObjectOfType<BasicTrollCombat>();
            StartCoroutine(TC.EnemyTurnStart());

        }

    }
























}
