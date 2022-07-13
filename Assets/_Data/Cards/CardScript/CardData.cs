using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : SaiMonoBehaviour
{
    public CardCtrl cardCtrl;
    [SerializeField] protected CardSO cardSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCardCtrl();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.LoadCardData();
    }

    protected virtual void LoadCardCtrl()
    {
        if (this.cardCtrl != null) return;
        this.cardCtrl = transform.parent.GetComponent<CardCtrl>();
        Debug.Log(transform.name + ": LoadCardCtrl", gameObject);
    }

    protected virtual void LoadCardData()
    {
        this.cardCtrl.cardImage.material = this.cardSO.image;
    }

    public virtual CardSO SetSO(CardSO cardSO)
    {
        this.cardSO = cardSO;
        return this.cardSO;
    }
}
