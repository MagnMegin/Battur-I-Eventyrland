using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomreVintreCombat : MonoBehaviour
{
    public int _dmg;
    public int _statusChance;
    public Unit unitScript;
    public CombatSystem combatScript;


    void Start()
    {
        unitScript = gameObject.GetComponent<Unit>();
        combatScript = FindObjectOfType<CombatSystem>();

    }
    public void Ability1()
    {
        

    }


    public void Ability2()
    {
        CombatSystem CS = FindObjectOfType<CombatSystem>();
        
    }

    public void BasicAttack()
    {
        Debug.Log(_dmg + " try attack");

        CombatSystem CS = FindObjectOfType<CombatSystem>();
        CS.state = BattleState.PLAYERTURN;
        CS.player1Buttons.SetActive(false);
        CS.player2Buttons.SetActive(false);
        CS._player2TurnDone = true;


        Debug.Log("PlayerInteract");

        Unit U = gameObject.GetComponent<Unit>();
        U.TakeDamage(_dmg, CS.enemyUnit);
    }
}
