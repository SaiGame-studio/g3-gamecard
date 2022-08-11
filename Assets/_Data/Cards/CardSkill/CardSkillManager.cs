using System.Collections.Generic;
using UnityEngine;

public class CardSkillManager : SaiMonoBehaviour
{
    private static CardSkillManager instance;
    public static CardSkillManager Instance { get => instance; }

    [SerializeField] protected List<CardSkill> cardSkills;

    protected override void Awake()
    {
        base.Awake();
        if (CardSkillManager.instance != null) Debug.LogError("Only 1 CardSkillManager allow");
        CardSkillManager.instance = this;

        this.HideAllSkill();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCardSkills();
    }

    protected virtual void LoadCardSkills()
    {
        if (this.cardSkills.Count > 0) return;

        CardSkill cardSkill;
        foreach(Transform child in transform)
        {
            cardSkill = child.GetComponent<CardSkill>();
            if (cardSkill == null) continue;
            this.cardSkills.Add(cardSkill);      
        }

        Debug.Log(transform.name + " LoadCardSkills", gameObject);
    }

    public virtual GameObject Create(SkillName skillName)
    {
        foreach(CardSkill cardSkill in this.cardSkills)
        {
            if (cardSkill.name != skillName.ToString()) continue;

            GameObject newSkill = Instantiate(cardSkill.gameObject);
            newSkill.name = cardSkill.name;
            return newSkill;
        }

        return null;
    }

    protected virtual void HideAllSkill()
    {
        foreach (CardSkill cardSkill in this.cardSkills)
        {
            cardSkill.gameObject.SetActive(false);
        }
    }
}
