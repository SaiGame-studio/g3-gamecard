using TMPro;
using UnityEngine;

public class CardData : SaiMonoBehaviour
{
    public CardCtrl cardCtrl;
    [SerializeField] protected CardSO cardSO;
    [SerializeField] protected TextMeshPro cardName;
    [SerializeField] protected TextMeshPro cardDescription;
    [SerializeField] protected TextMeshPro cardAttack;
    [SerializeField] protected TextMeshPro cardDefend;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCardCtrl();
        this.LoadCardName();
        this.LoadCardDescription();
        this.LoadCardAttributes();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.LoadCardData();
    }

    protected virtual void LoadCardCtrl()
    {
        if (this.cardCtrl != null) return;
        this.cardCtrl = transform.parent.GetComponent<CardCtrl>();
        Debug.Log(transform.name + ": LoadCardCtrl", gameObject);
    }

    protected virtual void LoadCardName()
    {
        if (this.cardName != null) return;
        this.cardName = transform.Find("CardName").GetComponent<TextMeshPro>();
        Debug.Log(transform.name + ": LoadCardName", gameObject);
    }

    protected virtual void LoadCardDescription()
    {
        if (this.cardDescription != null) return;
        this.cardDescription = transform.Find("CardDescription").GetComponent<TextMeshPro>();
        Debug.Log(transform.name + ": LoadCardDescription", gameObject);
    }

    protected virtual void LoadCardAttributes()
    {
        if (this.cardAttack != null) return;
        this.cardAttack = transform.Find("CardAttack").GetComponent<TextMeshPro>();
        this.cardDefend = transform.Find("CardDefend").GetComponent<TextMeshPro>();
        Debug.Log(transform.name + ": LoadCardAttributes", gameObject);
    }

    protected virtual void LoadCardData()
    {
        if (this.cardSO == null) return;
        this.cardCtrl.cardImage.material = this.cardSO.image;
        this.cardName.text = this.cardSO.cardName;
        this.cardDescription.text = this.cardSO.cardDescription;
        this.cardAttack.text = this.cardSO.attack.ToString();
        this.cardDefend.text = this.cardSO.defend.ToString();
    }

    public virtual CardSO SetSO(CardSO cardSO)
    {
        this.cardSO = cardSO;
        return this.cardSO;
    }
}
