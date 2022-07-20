using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDesk : DeskManager
{
    private static EnemyDesk instance;
    public static EnemyDesk Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (EnemyDesk.instance != null) Debug.LogError("Only 1 EnemyDesk allow");
        EnemyDesk.instance = this;
    }
}
