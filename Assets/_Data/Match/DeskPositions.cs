using System.Collections.Generic;
using UnityEngine;

public class DeskPositions : SaiMonoBehaviour
{
    public Transform myDeskPos;
    public Transform mySummonPos;

    public Transform enemyDeskPos;
    public Transform enemySummonPos;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadMyDeskPos();
        this.LoadMySummonPos();

        this.LoadEnemyDeskPos();
        this.LoadEnemySummonPos();
    }

    protected virtual void LoadMyDeskPos()
    {
        if (this.myDeskPos != null) return;
        this.myDeskPos = transform.Find("MyDeskPos");
        Debug.Log(transform.name + ": LoadMyDeskPos", gameObject);
    }

    protected virtual void LoadMySummonPos()
    {
        if (this.mySummonPos != null) return;
        this.mySummonPos = transform.Find("MySummonPos");
        Debug.Log(transform.name + ": LoadMySummonPos", gameObject);
    }



    protected virtual void LoadEnemyDeskPos()
    {
        if (this.enemyDeskPos != null) return;
        this.enemyDeskPos = transform.Find("EnemyDeskPos");
        Debug.Log(transform.name + ": LoadEnemyDeskPos", gameObject);
    }

    protected virtual void LoadEnemySummonPos()
    {
        if (this.enemySummonPos != null) return;
        this.enemySummonPos = transform.Find("EnemySummonPos");
        Debug.Log(transform.name + ": LoadEnemySummonPos", gameObject);
    }
}
