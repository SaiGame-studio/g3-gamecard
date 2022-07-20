using System;
using System.Collections.Generic;
using UnityEngine;

public class MyDesk : DeskManager
{
    private static MyDesk instance;
    public static MyDesk Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (MyDesk.instance != null) Debug.LogError("Only 1 MyDesk allow");
        MyDesk.instance = this;
    }
}
