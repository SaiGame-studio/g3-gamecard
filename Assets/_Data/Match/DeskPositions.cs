using System.Collections.Generic;
using UnityEngine;

public class DeskPositions : SaiMonoBehaviour
{

    [SerializeField] protected Transform myDeskPos;
    [SerializeField] protected Transform mySummonPos;
    [SerializeField] protected List<CardPosition> myFrontLines;
    [SerializeField] protected List<CardPosition> myBackLines;

    [SerializeField] protected Transform enemyDeskPos;
    [SerializeField] protected Transform enemySummonPos;
    [SerializeField] protected List<CardPosition> enemyFrontLines;
    [SerializeField] protected List<CardPosition> enemyBackLines;

    public Transform MyDeskPos { get => myDeskPos; }
    public Transform MySummonPos { get => mySummonPos; }
    public List<CardPosition> MyFrontLines { get => myFrontLines; }
    public List<CardPosition> MyBackLines { get => myBackLines; }

    public Transform EnemyDeskPos { get => enemyDeskPos; }
    public Transform EnemySummonPos { get => enemySummonPos; }
    public List<CardPosition> EnemyFrontLines { get => enemyFrontLines; }
    public List<CardPosition> EnemyBackLines { get => enemyBackLines; }

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
            this.myBackLines.Add(line.GetComponent<CardPosition>());
        }
        Debug.Log(transform.name + ": LoadMyBackLine", gameObject);
    }

    protected virtual void LoadMyFrontLines()
    {
        if (this.MyFrontLines.Count > 0) return;

        Transform lines = transform.Find("MyFrontLines");
        foreach (Transform line in lines)
        {
            this.MyFrontLines.Add(line.GetComponent<CardPosition>());
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
        if (this.EnemyBackLines.Count > 0) return;

        Transform lines = transform.Find("EnemyBackLines");
        foreach (Transform line in lines)
        {
            this.EnemyBackLines.Add(line.GetComponent<CardPosition>());
        }
        Debug.Log(transform.name + ": LoadEnemyBackLines", gameObject);
    }

    protected virtual void LoadEnemyFrontLines()
    {
        if (this.EnemyFrontLines.Count > 0) return;

        Transform lines = transform.Find("EnemyFrontLines");
        foreach (Transform line in lines)
        {
            this.EnemyFrontLines.Add(line.GetComponent<CardPosition>());
        }
        Debug.Log(transform.name + ": LoadEnemyFrontLines", gameObject);
    }

    public virtual CardPosition GetAvailablePosition(LineType lineType)
    {
        List<CardPosition> lines;

        switch (lineType)
        {
            case LineType.myFrontLine:
                lines = this.myFrontLines;
                break;
            case LineType.myBackLine:
                lines = this.myBackLines;
                break;
            case LineType.enemyFrontLine:
                lines = this.enemyFrontLines;
                break;
            case LineType.enemyBackLine:
                lines = this.enemyBackLines;
                break;
            default:
                Debug.LogError("Get Available Position: undefind LineType " + lineType.ToString());
                return null;
        }

        foreach (CardPosition line in lines)
        {
            if (line.IsAvailable()) return line;
        }

        return null;
    }
}
