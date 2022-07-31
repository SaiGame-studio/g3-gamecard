using System.Collections.Generic;
using UnityEngine;

public class CardPositions : SaiMonoBehaviour
{
    public Transform mainDeskPos;
    public Transform summonDeskPos;
    public List<CardPosition> frontLines;
    public List<CardPosition> backLines;
    public List<CardPosition> handCards;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadMainDeskPos();
        this.LoadSummonDeskPos();
        this.LoadFrontLines();
        this.LoadBackLines();
        this.LoadHandCards();
    }

    protected virtual void LoadMainDeskPos()
    {
        if (this.mainDeskPos != null) return;
        this.mainDeskPos = transform.Find("MainDeskPos");
        Debug.Log(transform.name + ": LoadMainDeskPos", gameObject);
    }

    protected virtual void LoadSummonDeskPos()
    {
        if (this.summonDeskPos != null) return;
        this.summonDeskPos = transform.Find("SummonDeskPos");
        Debug.Log(transform.name + ": LoadSummonDeskPos", gameObject);
    }

    protected virtual void LoadFrontLines()
    {
        if (this.frontLines.Count > 0) return;

        Transform lines = transform.Find("FrontLines");
        foreach (Transform line in lines)
        {
            this.frontLines.Add(line.GetComponent<CardPosition>());
        }
        Debug.Log(transform.name + ": LoadFrontLines", gameObject);
    }

    protected virtual void LoadBackLines()
    {
        if (this.backLines.Count > 0) return;

        Transform lines = transform.Find("BackLines");
        foreach (Transform line in lines)
        {
            this.backLines.Add(line.GetComponent<CardPosition>());
        }
        Debug.Log(transform.name + ": LoadBackLines", gameObject);
    }

    protected virtual void LoadHandCards()
    {
        if (this.handCards.Count > 0) return;

        Transform lines = transform.Find("HandCards");
        foreach (Transform line in lines)
        {
            this.handCards.Add(line.GetComponent<CardPosition>());
        }
        Debug.Log(transform.name + ": LoadHandCards", gameObject);
    }

    public virtual CardPosition GetAvailablePosition(LineType lineType)
    {
        List<CardPosition> lines;

        switch (lineType)
        {
            case LineType.frontLine:
                lines = this.frontLines;
                break;
            case LineType.backLine:
                lines = this.backLines;
                break;
            case LineType.handCard:
                lines = this.handCards;
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
