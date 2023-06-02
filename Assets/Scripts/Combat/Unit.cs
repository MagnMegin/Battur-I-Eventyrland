using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public string unitName;

    public int damage;
    public int maxPoints;
    public int currentPoints;
    public int ability1Cost;
    public int ability2Cost;

    public int maxHP;
    public int currentHP;

    public bool defenceDown = false;
    public bool _frozen = false;
    public bool _burning = false;
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
                CS.dialogueText.text = "En av dere døde! Prøv igjen";
            }
            else if (unit == CS.enemyUnit)
            {
                Debug.Log("Enemy Dead");
                CS.state = BattleState.WON;
                CS.dialogueText.text = CS.enemyUnit.unitName + " er død! Dere vant kampen!";
                StartCoroutine(CS.CombatWon());
            }
        }
        else
        {
            NoHealthLeft = false;
            Debug.Log("Health = plenty");
            StartCoroutine(CS.DamageUpdate());
        }

    }

    public IEnumerator Heal(int heal, Unit unit)
    {
        yield return new WaitForSeconds(2f);
        unit.currentHP = unit.currentHP + heal;

        if (unit.currentHP > unit.maxHP)
        {
            unit.currentHP = unit.maxHP;
        }

        CombatSystem CS = FindObjectOfType<CombatSystem>();

        StartCoroutine(CS.HealPlayers());

    }
}
