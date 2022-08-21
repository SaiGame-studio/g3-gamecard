using UnityEngine;

public class SkillAttackTarget : CardSkill
{
    public override void Active()
    {
        this.targetChoosing = true;
    }

    protected override void SkillActive()
    {
        base.SkillActive();

        foreach(CardCtrl target in this.targets)
        {
            this.AttackTarget(this.cardCtrl,target);
        }

        this.ClearTargets();
    }

    protected virtual void AttackTarget(CardCtrl attacker, CardCtrl target)
    {
        int attackerDamage = attacker.cardData.CardSO.attack;

        //TODO: check card status is attack or defence
        int targetDamage = target.cardData.CardSO.attack;

        //TODO: card type is Leader, Normal or Summon
        if (attackerDamage >= targetDamage) target.managerDesk.Line2Desk(target, LineType.mainDesk);
        else attacker.managerDesk.Line2Desk(target, LineType.mainDesk);
    }
}
