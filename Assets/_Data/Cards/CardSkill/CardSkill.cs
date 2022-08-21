using System.Collections.Generic;
using UnityEngine;

public abstract class CardSkill : SaiMonoBehaviour
{
    [SerializeField] protected CardCtrl cardCtrl;
    [SerializeField] protected bool processing = false;
    [SerializeField] protected bool targetChoosing = false;
    [SerializeField] protected bool hasEnoughTarget = false;
    [SerializeField] protected int targetLimit = 1;
    [SerializeField] protected List<CardCtrl> targets;

    public List<CardCtrl> Targets { get => targets;}

    public abstract void Active();

    protected virtual void SkillActive()
    {
        this.TargetsFaceUp();
    }

    protected virtual void ClearTargets()
    {
        this.targets.Clear();
        this.hasEnoughTarget = false;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Processing();
    }

    public virtual void SetCardCtrl(CardCtrl cardCtrl)
    {
        this.cardCtrl = cardCtrl;
        this.targetLimit = this.cardCtrl.cardData.CardSO.targetCount;
    }

    protected virtual void Processing()
    {
        if (!MatchManager.Instance.IsCardAttacking(this.cardCtrl)) this.DeactiveSkill();
        if (!MatchManager.Instance.IsCurrentDesk(this.cardCtrl.managerDesk)) this.DeactiveSkill();

        if (this.targetChoosing) this.TargetChoosing();
        if (this.hasEnoughTarget) this.SkillActive();
    }

    protected virtual void DeactiveSkill()
    {
        this.processing = false;
        this.targetChoosing = false;
        this.hasEnoughTarget = false;
    }

    protected virtual void TargetChoosing()
    {
        if (this.hasEnoughTarget) return;

        if (this.targets.Count >= this.targetLimit)
        {
            this.hasEnoughTarget = true;
            this.targetChoosing = false;
            return;
        }

        CardCtrl lastCardChoose = MatchManager.Instance.cardChoose;
        if (lastCardChoose == null) return;
        if (lastCardChoose == this.cardCtrl) return;
        if (lastCardChoose.cardPosition == null) return;
        if (this.cardCtrl.managerDesk == lastCardChoose.managerDesk) return;

        if (lastCardChoose.cardPosition.LineType != LineType.FrontLines) return;
        if (this.targets.Contains(lastCardChoose)) return;

        this.targets.Add(lastCardChoose);

        Debug.Log(transform.parent.parent.name + ": Target Choose " + lastCardChoose.name, gameObject);
    }

    protected virtual void TargetsFaceUp()
    {
        foreach (CardCtrl target in this.targets)
        {
            target.cardMovement.FaceUp();
        }
    }

}
