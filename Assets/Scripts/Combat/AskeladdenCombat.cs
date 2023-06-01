using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskeladdenCombat : MonoBehaviour
{
    public int _dmg;
    public int _heal;
    public Unit unitScript;
    public CombatSystem combatScript;
    public BasicTrollCombat trollScript;


    void Start()
    {

        unitScript = gameObject.GetComponent<Unit>();
        combatScript = FindObjectOfType<CombatSystem>();
        trollScript = FindObjectOfType<BasicTrollCombat>();

      //  SetupDMG(combatScript.player1Unit);





    }
    public void Ability1()
    {
        CombatSystem CS = FindObjectOfType<CombatSystem>();
        if (CS.player1Unit.currentPoints > CS.player1Unit.ability1Cost)
        {
            CS.dialogueText.text = CS.player1Unit.unitName + " har ikke nok evne poeng til å gjøre det!";
        }


        Debug.Log("Pick heal target");
        CS.healPick.SetActive(true);
        CS.player1Buttons.SetActive(false);
        CS.player2Buttons.SetActive(false);
        CS.state = BattleState.PLAYERINTERACT;
        CS.dialogueText.text = "Hvem helbreder du " + _heal + " helse til?";
    }

    public void Ability1ActivateAsk()
    {
        CombatSystem CS = FindObjectOfType<CombatSystem>();
        Unit U = gameObject.GetComponent<Unit>();
        CS._player1TurnDone = true;
        StartCoroutine(U.Heal(_heal, CS.player1Unit));
        CS.healPick.SetActive(false);


    }

    public void Ability1ActivateCompanion()
    {
        CombatSystem CS = FindObjectOfType<CombatSystem>();
        Unit U = gameObject.GetComponent<Unit>();
        CS._player1TurnDone = true;
        StartCoroutine(U.Heal(_heal, CS.player2Unit));
        CS.healPick.SetActive(false);
    }






    public void Ability2()
    {
        CombatSystem CS = FindObjectOfType<CombatSystem>();
        CS.player1Buttons.SetActive(false);
        CS.player2Buttons.SetActive(false);
        CS.state = BattleState.PLAYERINTERACT;
        StartCoroutine(Ability2Interaction());
    }

    public IEnumerator Ability2Interaction()
    {
        yield return new WaitForSeconds(3f);

        CombatSystem CS = FindObjectOfType<CombatSystem>();
        BasicTrollCombat Troll = FindObjectOfType<BasicTrollCombat>();
        CS.enemyUnit.defenceDown = true;
        Troll._currentDefenceTime = Troll._defenceCooldown;
        CS.dialogueText.text = "Askeladden skremte " + CS.enemyUnit.unitName + "! Nå tar'n mer skade!";
        CS._player1TurnDone = true;

        StartCoroutine(CS.DamageUpdate());
    }






    public void BasicAttack()
    {
        Debug.Log(_dmg + " try attack");

        CombatSystem CS = FindObjectOfType<CombatSystem>();
        CS.state = BattleState.PLAYERINTERACT;
        CS.player1Buttons.SetActive(false);
        CS.player2Buttons.SetActive(false);

        StartCoroutine(BasicAttackInteraction());
    }

    public IEnumerator BasicAttackInteraction()
    {
        yield return new WaitForSeconds(3f);

        Debug.Log("PlayerInteract");
        CombatSystem CS = FindObjectOfType<CombatSystem>();
        Unit U = gameObject.GetComponent<Unit>();
        U.TakeDamage(_dmg, CS.enemyUnit);
        CS._player1TurnDone = true;
    }


    //public void SetupDMG(Unit self)
    //{
    //    dmg = self.damage;
    //    Debug.Log(dmg + " setup");
    //}

}
