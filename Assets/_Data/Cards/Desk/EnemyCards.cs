using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCards : CardManager
{
    private static EnemyCards instance;
    public static EnemyCards Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (EnemyCards.instance != null) Debug.LogError("Only 1 EnemyCards allow");
        EnemyCards.instance = this;
    }
}
