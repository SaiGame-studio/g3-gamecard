using UnityEngine;

public class CardClicked : CardCtrlAbstract
{
    [SerializeField] protected bool isLeftClick = false;
    [SerializeField] protected bool isRightClick = false;
    [SerializeField] protected bool isMiddleClick = false;

    protected virtual void OnMouseOver()
    {
        this.isLeftClick = Input.GetMouseButtonDown(0);
        this.isRightClick = Input.GetMouseButtonDown(1);
        this.isMiddleClick = Input.GetMouseButtonDown(2);

        if (this.isLeftClick) this.OnMainClicked();
        if (this.isRightClick) this.OnActiveClicked();
        if (this.isMiddleClick) this.OnMiddleClicked();
    }

    protected virtual void OnActiveClicked()
    {
        Debug.Log(transform.parent.name + " On Active Clicked", gameObject);
    }

    protected virtual void OnMiddleClicked()
    {
        Debug.Log(transform.parent.name + " On Middle Clicked", gameObject);
    }

    protected virtual void OnMainClicked()
    {
        CardPosition cardPosition = this.cardCtrl.cardPosition;
        if (cardPosition == null) return;

            switch (cardPosition.LineType)
        {
            case LineType.HandCards:
                this.cardCtrl.managerDesk.SendHandCard2Line(cardCtrl);
                break;
            default:
                this.cardCtrl.cardMovement.SwitchPosition();
                break;
        }
    }
}
