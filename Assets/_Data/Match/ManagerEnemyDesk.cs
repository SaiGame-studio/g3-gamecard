using System.Collections.Generic;
using UnityEngine;

public class ManagerEnemyDesk : ManagerDesk
{
    private static ManagerEnemyDesk instance;
    public static ManagerEnemyDesk Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (ManagerEnemyDesk.instance != null) Debug.LogError("Only 1 ManagerEnemyDesk allow");
        ManagerEnemyDesk.instance = this;
    }

    protected override string DeskName()
    {
        return "EnemyCards";
    }
}
