using System.Collections.Generic;
using UnityEngine;

public class DeskPositions : SaiMonoBehaviour
{
    public Transform myDeskPos;
    public Transform mySummonPos;
    public List<Transform> myBackLines;
    public List<Transform> myFrontLines;

    public Transform enemyDeskPos;
    public Transform enemySummonPos;
    public List<Transform> enemyBackLines;
    public List<Transform> enemyFrontLines;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadMyDeskPos();
        this.LoadMySummonPos();
        this.LoadMyBackLines();
        this.LoadMyFrontLines();

        this.LoadEnemyDeskPos();
        this.LoadEnemySummonPos();
        this.LoadEnemyBackLines();
        this.LoadEnemyFrontLines();
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

    protected virtual void LoadMyBackLines()
    {
        if (this.myBackLines.Count > 0) return;

        Transform lines = transform.Find("MyBackLines");
        foreach (Transform line in lines)
        {
            this.myBackLines.Add(line);
        }
        Debug.Log(transform.name + ": LoadMyBackLine", gameObject);
    }

    protected virtual void LoadMyFrontLines()
    {
        if (this.myFrontLines.Count > 0) return;

        Transform lines = transform.Find("MyFrontLines");
        foreach (Transform line in lines)
        {
            this.myFrontLines.Add(line);
        }
        Debug.Log(transform.name + ": LoadMyFrontLines", gameObject);
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

    protected virtual void LoadEnemyBackLines()
    {
        if (this.enemyBackLines.Count > 0) return;

        Transform lines = transform.Find("EnemyBackLines");
        foreach (Transform line in lines)
        {
            this.enemyBackLines.Add(line);
        }
        Debug.Log(transform.name + ": LoadEnemyBackLines", gameObject);
    }

    protected virtual void LoadEnemyFrontLines()
    {
        if (this.enemyFrontLines.Count > 0) return;

        Transform lines = transform.Find("EnemyFrontLines");
        foreach (Transform line in lines)
        {
            this.enemyFrontLines.Add(line);
        }
        Debug.Log(transform.name + ": LoadEnemyFrontLines", gameObject);
    }
}
