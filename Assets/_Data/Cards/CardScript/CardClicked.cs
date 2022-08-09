using UnityEngine;

public class CardClicked : SaiMonoBehaviour
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

    protected virtual void OnMouseDown()
    {
        CardPosition cardPosition = this.cardCtrl.cardPosition;

        switch (cardPosition.LineType)
        {
            case LineType.HandCards:
                this.cardCtrl.managerDesk.SendHandCard2Line(cardCtrl);
                break;
            default:
                cardCtrl.cardMovement.SwitchPosition();
                break;
        }

        //string positionName = cardPosition.transform.parent.name;
        //Debug.Log(transform.parent.name + ": OnMouseDown " + positionName, gameObject);
    }
}
