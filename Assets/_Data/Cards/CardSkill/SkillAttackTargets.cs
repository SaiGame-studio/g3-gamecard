using System.Collections.Generic;
using UnityEngine;

public class SkillAttackTargets : CardSkill
{
    [SerializeField] protected List<CardCtrl> targets;

    public override void Active()
    {
        int targetCount = this.cardCtrl.cardData.CardSO.targetCount;
        Debug.Log(transform.parent.parent.name + " SkillAttackTargets "+ targetCount.ToString(), gameObject);
    }

    protected override void SkillActive()
    {
        throw new System.NotImplementedException();
    }
}
