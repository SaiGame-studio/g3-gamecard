using UnityEngine;

public class SkillAttackTarget : CardSkill
{
    [SerializeField] protected CardCtrl target;

    public override void Active()
    {
        Debug.Log(transform.parent.parent.name + " SkillAttackTarget", gameObject);
    }
}
