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
    public Unit unitScript;
    public CombatSystem combatScript;


    void Start()
    {

        unitScript = gameObject.GetComponent<Unit>();
        combatScript = FindObjectOfType<CombatSystem>();

    }


    public IEnumerator EnemyTurnStart()
    {
        yield return new WaitForSeconds(3f);

        DefenceDownTimer();

        Unit U = gameObject.GetComponent<Unit>();
        CombatSystem CS = FindObjectOfType<CombatSystem>();
        _chooseTarget = Random.Range(1, 2);
        _chooseAttackType = Random.Range(1, 2);
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
            if (Random.Range(1, 2) > 1)
            {
                //Punch//
                Debug.Log("Punch");
                CS.state = BattleState.ENEMYINTERACT;

                _dmg = Random.Range(_minDMG, _maxDMG);
                Debug.Log("Random damage = " + _dmg);

                CS._enemyTurnDone = true;

                U.TakeDamage(_dmg, CS.player1Unit);

            }
            else if (Random.Range(1, 2) < 1)
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
        else
        {
            Debug.Log("Failed to choose target");
        }

    }

    public void DefenceDownTimer()
    {

    }


}
