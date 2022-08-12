using UnityEngine;

public class SkillAttackTarget : CardSkill
{
    [SerializeField] protected CardCtrl target;

    public override void Active()
    {
        this.targetChoosing = true;
    }

    protected override void SkillActive()
    {
        throw new System.NotImplementedException();
    }
}
