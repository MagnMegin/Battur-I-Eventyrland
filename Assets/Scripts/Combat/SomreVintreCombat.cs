using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomreVintreCombat : MonoBehaviour
{
    public int _dmg;
    public int _windDMG;
    public int _minDMG;
    public int _maxDMG;
    public int _statusChance;
    public Unit unitScript;
    public CombatSystem combatScript;
    public BasicTrollCombat trollScript;



    void Start()
    {
        unitScript = gameObject.GetComponent<Unit>();
        combatScript = FindObjectOfType<CombatSystem>();
        trollScript = gameObject.GetComponent<BasicTrollCombat>();

    }
    public void Ability1()
    {
        Debug.Log("Trykk masse på Q for å blåse hardere!");
        CombatSystem CS = FindObjectOfType<CombatSystem>();
        CS.player1Buttons.SetActive(false);
        CS.player2Buttons.SetActive(false);
        CS.state = BattleState.PLAYERINTERACT;
        CS.dialogueText.text = "Trykk masse på Q for å blåse hardere!";

        StartCoroutine(BlowColdInteraction());

    }

    public IEnumerator BlowColdInteraction()
    {
        yield return new WaitForSeconds(3f);

        Debug.Log("PlayerInteract");

        CombatSystem CS = FindObjectOfType<CombatSystem>();
        Unit U = gameObject.GetComponent<Unit>();

        _windDMG = Random.Range(_minDMG, _maxDMG);
        Debug.Log("Random damage = " + _windDMG);

        _statusChance = Random.Range(1, 3);
        if (_statusChance == 1)
        {
            CS.enemyUnit._frozen = true;
            BasicTrollCombat Troll = FindObjectOfType<BasicTrollCombat>();
            Troll._currentCooldownTime = Troll._statusCooldown;
            if (CS.enemyUnit._burning == true)
            {
                CS.enemyUnit._burning = false;
                CS.dialogueText.text = "Eivind frosna " + CS.enemyUnit.unitName + "! Men det slukna'n...";
            }
            else
            {
                CS.dialogueText.text = "Eivind frosna " + CS.enemyUnit.unitName + "!";
            }
        }
        else
        {
            Debug.Log("Failed to freeze");
        }

        U.TakeDamage(_windDMG, CS.enemyUnit);
        CS._player2TurnDone = true;


    }

    public void Ability2()
    {
        Debug.Log("Trykk masse på Q for å blåse hardere!");
        CombatSystem CS = FindObjectOfType<CombatSystem>();
        CS.player1Buttons.SetActive(false);
        CS.player2Buttons.SetActive(false);
        CS.state = BattleState.PLAYERINTERACT;
        CS.dialogueText.text = "Trykk masse på Q for å blåse hardere!";

        StartCoroutine(BlowWarmInteraction());
    }

    public IEnumerator BlowWarmInteraction()
    {
        yield return new WaitForSeconds(3f);

        Debug.Log("PlayerInteract");

        CombatSystem CS = FindObjectOfType<CombatSystem>();
        Unit U = gameObject.GetComponent<Unit>();

        _windDMG = Random.Range(_minDMG, _maxDMG);
        Debug.Log("Random damage = " + _windDMG);

        _statusChance = Random.Range(1, 3);
        if (_statusChance == 1)
        {
            CS.enemyUnit._burning = true;
            BasicTrollCombat Troll = FindObjectOfType<BasicTrollCombat>();
            Troll._currentCooldownTime = Troll._statusCooldown;
            if (CS.enemyUnit._frozen == true)
            {
                CS.enemyUnit._frozen = false;
                CS.dialogueText.text = "Eivind satt fyr på " + CS.enemyUnit.unitName + "! Men det tinte'n...";
            }
            else
            {
                CS.dialogueText.text = "Eivind satt fyr på " + CS.enemyUnit.unitName + "!";
            }
        }
        else
        {
            Debug.Log("Failed to burn");
        }

        U.TakeDamage(_windDMG, CS.enemyUnit);
        CS._player2TurnDone = true;
    }


    public void BasicAttack()
    {
        Debug.Log(_dmg + " try attack");

        CombatSystem CS = FindObjectOfType<CombatSystem>();
        CS.state = BattleState.PLAYERTURN;
        CS.player1Buttons.SetActive(false);
        CS.player2Buttons.SetActive(false);
        CS.state = BattleState.PLAYERINTERACT;
        StartCoroutine(BasicAttackInteraction());
    }

    public IEnumerator BasicAttackInteraction()
    {
        yield return new WaitForSeconds(3f);

        Debug.Log("PlayerInteract");

        CombatSystem CS = FindObjectOfType<CombatSystem>();
        Unit U = gameObject.GetComponent<Unit>();
        U.TakeDamage(_dmg, CS.enemyUnit);
        CS._player2TurnDone = true;
    }



}
