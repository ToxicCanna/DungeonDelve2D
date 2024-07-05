using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public EnemyBase Base 
    { 
        get; set; 
    }
    public int Level
    {
        get; set;
    }

    public int HP
    {
        get; set;
    }

    public List<Skill> Skills
    {
        get; set;
    }

    public Enemy(EnemyBase eBase, int eLevel)
    {
        Base = eBase;
        Level = eLevel;
        HP = MaxHp;

        //Generate Skills
        Skills = new List<Skill>();
            foreach (var skill in Base.LearnableSkills)
        {
            if (skill.Level <= Level)
                Skills.Add(new Skill(skill.Base));
        }
    }
    public int MaxHp
    {
        get
        {
            return Mathf.FloorToInt((Base.MaxHp * Level) / 100f) + 10;
        }
    }

    public int Attack
    {
        get
        {
            return Mathf.FloorToInt((Base.Attack * Level) / 100f) + 5;
        }
    }

    public int Defense
    {
        get
        {
            return Mathf.FloorToInt((Base.Defense * Level) / 100f) + 5;
        }
    }

    public int Focus
    {
        get
        {
            return Mathf.FloorToInt((Base.Focus * Level) / 100f) + 5;
        }
    }

    public int Dexterity
    {
        get
        {
            return Mathf.FloorToInt((Base.Dexterity * Level) / 100f) + 5;
        }
    }

    public int Resist
    {
        get
        {
            return Mathf.FloorToInt((Base.Resist * Level) /1000f);
        }
    }

    public bool TakeDamage(Skill skill, Enemy attacker)
    {
        float modifiers = Random.Range(0.85f, 1f);
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * skill.Base.Power * ((float)attacker.Attack / Defense) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);

        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            return true;
        }

        return false;
    }

    public Skill GetRandomSkill()
    {
        int r = Random.Range(0, Skills.Count);
        return Skills[r];
    }
}
