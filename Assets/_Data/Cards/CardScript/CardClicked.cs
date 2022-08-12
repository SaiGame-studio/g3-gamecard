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

        if (this.isLeftClick)
        {
            MatchManager.Instance.ChooseCard(this.cardCtrl);
            this.OnMainActive();
        }

        if (this.isRightClick) this.OnSecondActive();
        if (this.isMiddleClick) this.OnMiddleActive();
    }

    protected virtual void OnSecondActive()
    {
        this.cardCtrl.cardAction.Active();
    }

    protected virtual void OnMiddleActive()
    {
        ManagerMyDesk.Instance.Line2Desk(this.cardCtrl, LineType.BackLines, LineType.mainDesk);
    }

    protected virtual void OnMainActive()
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
