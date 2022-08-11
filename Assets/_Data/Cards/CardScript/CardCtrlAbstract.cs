using UnityEngine;

public abstract class CardCtrlAbstract : SaiMonoBehaviour
{
    public CardCtrl cardCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCardCtrl();
    }

    protected virtual void LoadCardCtrl()
    {
        if (this.cardCtrl != null) return;
        this.cardCtrl = transform.parent.GetComponent<CardCtrl>();
        Debug.Log(transform.name + ": LoadCardCtrl", gameObject);
    }
}
