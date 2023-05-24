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

    public bool NoHealthLeft;

    public CombatActions Actions;

    private void Awake()
    {
        Actions = (CombatActions)GetComponent(typeof(CombatActions));
    }


    public void TakeDamage(int dmg, Unit unit)
    {
        unit.currentHP = unit.currentHP - dmg;

        if (unit.currentHP <= 0)
        {
            NoHealthLeft = true;
            Debug.Log("Health = none");
        }
        else
        {
            NoHealthLeft = false;
            Debug.Log("Health = plenty");
        }

        CombatSystem CS = FindObjectOfType<CombatSystem>();

        CS.DamageEnemy();
    }

    public void Heal(int heal, Unit unit)
    {
        unit.currentHP = unit.currentHP + heal;

        if (unit.currentHP > unit.maxHP)
        {
            unit.currentHP = unit.maxHP;
        }

        CombatSystem CS = FindObjectOfType<CombatSystem>();

        CS.HealPlayers();

    }
}
