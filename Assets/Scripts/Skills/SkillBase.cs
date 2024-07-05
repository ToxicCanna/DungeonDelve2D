using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill/Create new Skill")]


public class SkillBase
    : ScriptableObject
{
    [SerializeField] string skillName;

    [TextArea]
    [SerializeField] string skillDescription;

    [SerializeField] EnemyType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int mana;

    public string Name
    {
        get
        {
            return skillName;
        }
    }
    public string SkillDescription
    {
        get
        {
            return skillDescription;
        }
    }
    public EnemyType Type
    {
        get
        {
            return type;
        }
    }
    public int Power
    {
        get
        {
            return power;
        }
    }
    public int Accuracy
    {
        get
        {
            return accuracy;
        }
    }
    public int Mana
    {
        get
        {
            return mana;
        }
    }
}
