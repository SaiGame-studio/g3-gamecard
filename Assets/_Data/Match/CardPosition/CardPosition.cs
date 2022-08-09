using System;
using UnityEngine;
using System.Collections;

public class CardPosition : SaiMonoBehaviour
{
    [SerializeField] protected CardCtrl card;
    [SerializeField] protected LineType lineType;

    public CardCtrl Card { get => card; }
    public LineType LineType { get => lineType; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLineType();
    }

    protected virtual void LoadLineType()
    {
        if (this.lineType != LineType.undefine) return;
        string positionName = transform.parent.name;
        this.lineType = (LineType)Enum.Parse(typeof(LineType), positionName);
        Debug.Log(transform.name + ": LoadLineType", gameObject);
    }

    public virtual bool IsAvailable()
    {
        return card == null;
    }

    public virtual void RemoveCard()
    {
        CardCtrl card = this.card;
        this.card = null;
        card.cardPosition = null;
    }

    public virtual void AddCard(CardCtrl cardCtrl)
    {
        this.card = cardCtrl;
    }
}
