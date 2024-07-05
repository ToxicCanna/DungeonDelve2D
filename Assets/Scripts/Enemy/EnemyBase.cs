using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Create new Enemy")]

public class EnemyBase : ScriptableObject
{
    [SerializeField] string enemyName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite playerSprite;
    [SerializeField] Sprite enemySprite;

    [SerializeField] EnemyType type1;
    [SerializeField] EnemyType type2;

    // base stats
    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int dexterity;
    [SerializeField] int focus;
    [SerializeField] int resist;

    [SerializeField] List<LearnableSkill> learnableSkills;

    public Sprite PlayerSprite
    {
        get
        {
            return playerSprite;
        }
    }

    public Sprite EnemySprite
    {
        get
        {
            return enemySprite;
        }
    }

    public EnemyType Type1
    {
        get
        {
            return type1;
        }
    }

    public EnemyType Type2
    {
        get
        {
            return type2;
        }
    }

    public string Name
    {
        get
        {
            return enemyName;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }
    }

    public int MaxHp
    {
        get
        {
            return maxHp;
        }
    }
    public int Attack
    {
        get
        {
            return attack;
        }
    }
    public int Defense
    {
        get
        {
            return defense;
        }
    }
    public int Focus
    {
        get
        {
            return focus;
        }
    }
    public int Dexterity
    {
        get
        {
            return dexterity;
        }
    }
    public int Resist
    {
        get
        {
            return resist;
        }
    }

    public List<LearnableSkill> LearnableSkills
    {
        get
        {
            return learnableSkills;
        }
    }
}

[System.Serializable]

public class LearnableSkill
{
    [SerializeField] SkillBase skillBase;
    [SerializeField] int level;

    public SkillBase Base
    {
        get
        {
            return skillBase;
        }
    }
    public int Level
    {
        get
        {
            return level;
        }
    }
}

public enum EnemyType
{
    None,
    Mortal,
    Fire,
    Water,
    Grass,
    Demon
}