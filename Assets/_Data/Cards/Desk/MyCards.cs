using System;
using System.Collections.Generic;
using UnityEngine;

public class MyCards : CardManager
{
    private static MyCards instance;
    public static MyCards Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (MyCards.instance != null) Debug.LogError("Only 1 MyCards allow");
        MyCards.instance = this;
    }
}
