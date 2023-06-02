using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTrollCombat : MonoBehaviour
{
    public int _dmg;
    public int _minDMG;
    public int _maxDMG;
    public int _chooseTarget;
    public int _chooseAttackType;
    public int _defenceCooldown;
    public int _currentDefenceTime;
    public int _statusCooldown;
    public int _currentCooldownTime;
    public int _burningDamage;
    public Unit unitScript;
    public CombatSystem combatScript;


    void Start()
    {

        unitScript = gameObject.GetComponent<Unit>();
        combatScript = FindObjectOfType<CombatSystem>();

    }


    public IEnumerator EnemyTurnStart()
    {
        yield return new WaitForSeconds(2f);

        DefenceDownTimer();
        BurningTimer();
        FrozenTimer();


        Unit U = gameObject.GetComponent<Unit>();
        CombatSystem CS = FindObjectOfType<CombatSystem>();

        if (CS.enemyUnit._frozen == true)
        {
            CS.dialogueText.text = CS.enemyUnit.unitName + " er frossen og kan ikke gjøre noe!";
            StartCoroutine(CS.DamageUpdate());
        }
        else
        { 
            _chooseTarget = Random.Range(1, 3);
            _chooseAttackType = Random.Range(1, 3);
            if (_chooseTarget == 1)
            {
                Debug.Log("Player 1 chosen");

                if (_chooseAttackType == 1)
                {
                        
                    //Punch//
                    Debug.Log("Punch");
                    CS.state = BattleState.ENEMYINTERACT;
                        
                    _dmg = Random.Range(_minDMG, _maxDMG);
                    Debug.Log("Random damage = " + _dmg);
                        
                    CS._enemyTurnDone = true;

                    U.TakeDamage(_dmg, CS.player1Unit);

                }
                else if (_chooseAttackType == 2)
                {

                    //Branch throw//
                    Debug.Log("Branch");
                    CS.state = BattleState.ENEMYINTERACT;

                    _dmg = Random.Range(_minDMG, _maxDMG);
                    Debug.Log("Random damage = " + _dmg);

                    CS._enemyTurnDone = true;

                    U.TakeDamage(_dmg, CS.player1Unit);

                }
                else
                {
                    Debug.Log("Failed to choose attack");
                }

            }
            else if (_chooseTarget == 2)
            {
                Debug.Log("Player 2 chosen");

                if (_chooseAttackType == 1)
                {
                    //Punch//
                    Debug.Log("Punch");
                    CS.state = BattleState.ENEMYINTERACT;

                    _dmg = Random.Range(_minDMG, _maxDMG);
                    Debug.Log("Random damage = " + _dmg);

                    CS._enemyTurnDone = true;

                    U.TakeDamage(_dmg, CS.player2Unit);

                }
                else if (_chooseAttackType == 2)
                {

                    //Branch throw//
                    Debug.Log("Branch");
                    CS.state = BattleState.ENEMYINTERACT;

                    _dmg = Random.Range(_minDMG, _maxDMG);
                    Debug.Log("Random damage = " + _dmg);

                    CS._enemyTurnDone = true;

                    U.TakeDamage(_dmg, CS.player2Unit);

                }
                else
                {
                Debug.Log("Failed to choose attack");
                }

            }
            else
            {
                Debug.Log("Failed to choose target");
            }

            CS.dialogueText.text = "Trollet skada dere!";

        }
    }

    public void DefenceDownTimer()
    {
        CombatSystem CS = FindObjectOfType<CombatSystem>();

        if (_currentDefenceTime > 0)
        {
            _currentDefenceTime = _currentDefenceTime - 1;
        }
        else
        {
            CS.enemyUnit.defenceDown = false;
            CS.dialogueText.text = CS.enemyUnit.unitName + " er ikke redd noe mer...";
        }
    }

    public void FrozenTimer()
    {
        CombatSystem CS = FindObjectOfType<CombatSystem>();
        if (_currentCooldownTime > 0)
        {
            _currentCooldownTime = _currentCooldownTime - 1;
        }
        else if (CS.enemyUnit._frozen == true)
        {
            CS.enemyUnit._frozen = false;
            CS.dialogueText.text = CS.enemyUnit.unitName + " har tint...";
        }
    }

    public void BurningTimer()
    {
        Unit U = gameObject.GetComponent<Unit>();
        CombatSystem CS = FindObjectOfType<CombatSystem>();

        if (_currentCooldownTime > 0)
        {
            _currentCooldownTime = _currentCooldownTime - 1;
            U.TakeDamage(_burningDamage, CS.enemyUnit);
        }
        else if (CS.enemyUnit._burning == true)
        {
            CS.enemyUnit._burning = false;
            CS.dialogueText.text = "Brannen på " + CS.enemyUnit.unitName + " har slukna...";
        }

    }

}
