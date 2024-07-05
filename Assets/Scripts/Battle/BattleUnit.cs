using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] EnemyBase _base;
    [SerializeField] int level;
    [SerializeField] bool isPlayer;

    public Enemy Enemy 
    { 
        get; set; 
    }

    public void Setup()
    {
        Enemy = new Enemy(_base, level);
        if(isPlayer)
            GetComponent<Image>().sprite = Enemy.Base.PlayerSprite;
        else
            GetComponent<Image>().sprite = Enemy.Base.EnemySprite;
    }
}
