using System.Collections.Generic;
using UnityEngine;

public class ManagerMyDesk : ManagerDesk
{
    private static ManagerMyDesk instance;
    public static ManagerMyDesk Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (ManagerMyDesk.instance != null) Debug.LogError("Only 1 ManagerMyDesk allow");
        ManagerMyDesk.instance = this;
    }

    protected override string DeskName()
    {
        return "MyCards";
    }
}
