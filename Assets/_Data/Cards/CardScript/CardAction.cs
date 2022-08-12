using UnityEngine;

public class CardAction : CardCtrlAbstract
{
    public CardSkill cardSkill;

    public virtual void Active()
    {
        this.cardCtrl.cardMovement.FaceUp();
        this.cardSkill.Active();
        Debug.Log(transform.parent.name + " CardAction", gameObject);
    }
}
