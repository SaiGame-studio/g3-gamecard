using UnityEngine;

public class CardCtrl : SaiMonoBehaviour
{
    public MeshRenderer cardImage;
    public CardData cardData;
    public CardMovement cardMovement;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCardImage();
        this.LoadCardData();
        this.LoadCardMovement();
    }

    protected virtual void LoadCardImage()
    {
        if (this.cardImage != null) return;
        this.cardImage = transform.Find("CardImage").GetComponent<MeshRenderer>();
        Debug.Log(transform.name + ": LoadCardImage", gameObject);
    }

    protected virtual void LoadCardData()
    {
        if (this.cardData != null) return;
        this.cardData = transform.Find("CardData").GetComponent<CardData>();
        Debug.Log(transform.name + ": LoadCardData", gameObject);
    }

    protected virtual void LoadCardMovement()
    {
        if (this.cardMovement != null) return;
        this.cardMovement = transform.Find("CardMovement").GetComponent<CardMovement>();
        Debug.Log(transform.name + ": LoadCardMovement", gameObject);
    }
}
