using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition
{
    public ConditionID Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string StartMessage { get; set; }

    public Action<Enemy> OnStart { get; set; }

    public Func<Enemy, bool> OnBeforeSkill { get; set; }

    public Action<Enemy> OnAfterTurn { get; set; }
}
