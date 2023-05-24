using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskeladdenCombat : MonoBehaviour, CombatActions
{
    public int _dmg;
    public int _heal;
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
        Debug.Log("Pick heal target");
        CombatSystem CS = FindObjectOfType<CombatSystem>();
        CS.healPick.SetActive(true);
        CS.player1Buttons.SetActive(false);
        CS.player2Buttons.SetActive(false);
        CS.state = BattleState.PLAYERTURN;
        CS.dialogueText.text = "Hvem helbreder du " + _heal + " helse til?";
    }

    public void Ability1ActivateAsk()
    {
        CombatSystem CS = FindObjectOfType<CombatSystem>();
        Unit U = gameObject.GetComponent<Unit>();
        CS._player1TurnDone = true;
        U.Heal(_heal, CS.player1Unit);
        CS.healPick.SetActive(false);


    }

    public void Ability1ActivateCompanion()
    {
        CombatSystem CS = FindObjectOfType<CombatSystem>();
        Unit U = gameObject.GetComponent<Unit>();
        CS._player1TurnDone = true;
        U.Heal(_heal, CS.player2Unit);
        CS.healPick.SetActive(false);
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
        CS.player1Buttons.SetActive(false);
        CS.player2Buttons.SetActive(false);
        CS._player1TurnDone = true;


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
