using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskeladdenCombat : MonoBehaviour, CombatActions
{
    public int _dmg;
    public Unit unitScript;
    public CombatSystem combatScript;


    void Start()
    {

        unitScript = gameObject.GetComponent<Unit>();
        combatScript = FindObjectOfType<CombatSystem>();

      //  SetupDMG(combatScript.player1Unit);





    }
    public void Ability1()
    { 
        throw new System.NotImplementedException();
    }

    public void Ability2()
    {
        throw new System.NotImplementedException();
    }

    public void BasicAttack()
    {
        Debug.Log(_dmg + " try attack");

        CombatSystem CS = FindObjectOfType<CombatSystem>();
        CS.state = BattleState.PLAYERTURN;
        Debug.Log("PlayerInteract");

        Unit U = gameObject.GetComponent<Unit>();
        U.TakeDamage(_dmg, CS.enemyUnit);
    }


    //public void SetupDMG(Unit self)
    //{
    //    dmg = self.damage;
    //    Debug.Log(dmg + " setup");
    //}

}
