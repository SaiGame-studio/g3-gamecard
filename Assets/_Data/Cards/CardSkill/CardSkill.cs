using UnityEngine;

public abstract class CardSkill : SaiMonoBehaviour
{
    public CardCtrl cardCtrl;
    [SerializeField] protected bool processing = false;
    [SerializeField] protected bool canActive = false;
    [SerializeField] protected bool targetChoosing = false;

    public abstract void Active();
    protected abstract void SkillActive();

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Processing();
    }

    protected virtual void Processing()
    {
        if (this.targetChoosing) this.TargetChoosing();
        if (this.canActive) this.SkillActive();
    }

    protected virtual void TargetChoosing()
    {
        CardCtrl lastCardChoose = MatchManager.Instance.cardChoose;
        if (lastCardChoose == this.cardCtrl) return;
        if (this.cardCtrl.managerDesk == lastCardChoose.managerDesk) return;
        if (lastCardChoose.cardPosition.LineType != LineType.FrontLines) return;

        Debug.Log(transform.parent.parent.name + ": Target Choose", gameObject);
    }

}
