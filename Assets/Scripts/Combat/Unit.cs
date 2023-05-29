using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public string unitName;

    public int damage;
    public int currentPoints;

    public int maxHP;
    public int currentHP;

    public bool defenceDown = false;
    public bool NoHealthLeft;

    public CombatActions Actions;

    private void Awake()
    {
        Actions = (CombatActions)GetComponent(typeof(CombatActions));
    }


    public void TakeDamage(int dmg, Unit unit)
    {
        CombatSystem CS = FindObjectOfType<CombatSystem>();
        if (unit.defenceDown == true)
        {
            unit.currentHP = unit.currentHP - (dmg + 2);
        }
        else
        {
            unit.currentHP = unit.currentHP - dmg;
        }

        if (unit.currentHP <= 0)
        {

            NoHealthLeft = true;
            Debug.Log("Health = none");
            if (unit == CS.player1Unit || CS.player2Unit)
            {
                Debug.Log("Player dead");
                CS.state = BattleState.LOST;
            }
            else if (unit == CS.enemyUnit)
            {
                Debug.Log("Enemy Dead");
                CS.state = BattleState.WON;
            }
        }
        else
        {
            NoHealthLeft = false;
            Debug.Log("Health = plenty");
        }

        StartCoroutine(CS.DamageUpdate());
    }

    public IEnumerator Heal(int heal, Unit unit)
    {
        yield return new WaitForSeconds(3f);
        unit.currentHP = unit.currentHP + heal;

        if (unit.currentHP > unit.maxHP)
        {
            unit.currentHP = unit.maxHP;
        }

        CombatSystem CS = FindObjectOfType<CombatSystem>();

        StartCoroutine(CS.HealPlayers());

    }
}
