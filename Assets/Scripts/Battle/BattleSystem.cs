using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { Start, PlayerAction, PlayerSkill, EnemySkill, Busy}

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleDialogBox dialogBox;

    BattleState state;
    int currentAction;
    int currentSkill;

    private void Start()
    {
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle()
    {
        playerUnit.Setup();
        enemyUnit.Setup();
        playerHud.SetData(playerUnit.Enemy);
        enemyHud.SetData(enemyUnit.Enemy);

        dialogBox.SetSkillNames(playerUnit.Enemy.Skills);

        yield return dialogBox.TypeDialog($"A dangerous {enemyUnit.Enemy.Base.Name} appeared!");
        yield return new WaitForSeconds(1f);

        PlayerAction();
    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose an action"));
        dialogBox.EnableActionSelector(true);
    }

    void PlayerSkill()
    {
        state = BattleState.PlayerSkill;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableSkillSelector(true);
    }

    IEnumerator PerformPlayerSkill()
    {
        state = BattleState.Busy;

        var skill = playerUnit.Enemy.Skills[currentSkill];
        yield return dialogBox.TypeDialog($"{playerUnit.Enemy.Base.Name} used {skill.Base.Name}");

        yield return new WaitForSeconds(1f);

        bool isFainted = enemyUnit.Enemy.TakeDamage(skill, playerUnit.Enemy);
        yield return enemyHud.UpdateHP();


        if (isFainted)
        {
            yield return dialogBox.TypeDialog($"{enemyUnit.Enemy.Base.Name} Died!");
        }
        else
        {
            StartCoroutine(EnemySkill());
        }
    }

    IEnumerator EnemySkill()
    {
        state = BattleState.EnemySkill;

        var skill = enemyUnit.Enemy.GetRandomSkill();
        yield return dialogBox.TypeDialog($"{enemyUnit.Enemy.Base.Name} used {skill.Base.Name}");

        yield return new WaitForSeconds(1f);

        bool isFainted = playerUnit.Enemy.TakeDamage(skill, playerUnit.Enemy);
        yield return playerHud.UpdateHP();

        if (isFainted)
        {
            yield return dialogBox.TypeDialog($"The {playerUnit.Enemy.Base.Name} Died!");
        }
        else
        {
            PlayerAction();
        }
    }

    private void Update()
    {
        if (state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        else if (state == BattleState.PlayerSkill)
        {
            HandleSkillSelection();
        }
        
    }

    void HandleActionSelection()
    {
        // TODO; implement new player system for battle controls

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            if (currentAction < 1)
                ++currentAction;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A))
        {
            if (currentAction > 0)
                --currentAction;
        }

        dialogBox.UpdateActionSelection(currentAction);

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (currentAction == 0)
            {
                //Attack
                PlayerSkill();
            }
            else if (currentAction == 1)
            {
                //Run
            }


        }
    }

    void HandleSkillSelection()
    {
        // TODO; implement new player system for battle controls
    
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
                if (currentSkill < playerUnit.Enemy.Skills.Count - 1)
                    ++currentSkill;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (currentSkill <= playerUnit.Enemy.Skills.Count - 6)
                currentSkill += 5;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (currentSkill > 0)
                --currentSkill;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (currentSkill >= 6)
                currentSkill -= 5;
        }

        dialogBox.UpdateSkillSelection(currentSkill, playerUnit.Enemy.Skills[currentSkill]);

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            dialogBox.EnableSkillSelector(false);
            dialogBox.EnableDialogText(true);
            StartCoroutine(PerformPlayerSkill());
        }
    }
}
