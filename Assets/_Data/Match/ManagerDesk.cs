using System.Collections.Generic;
using UnityEngine;

public abstract class ManagerDesk : SaiMonoBehaviour
{
    [SerializeField] protected CardPositions cardPositions;

    [SerializeField] protected CardManager cardManager;
    [SerializeField] protected List<CardCtrl> mainDesk;
    [SerializeField] protected List<CardCtrl> summonDesk;

    protected override void Start()
    {
        this.SpawmCards();
    }

    protected abstract string DeskName();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCardManager();
        this.LoadDeskPositions();
    }

    protected virtual void LoadCardManager()
    {
        if (this.cardManager != null) return;
        this.cardManager = GameObject.Find(this.DeskName()).GetComponent<CardManager>();
        Debug.Log(transform.name + ": LoadCardManager", gameObject);
    }

    protected virtual void LoadDeskPositions()
    {
        if (this.cardPositions != null) return;
        this.cardPositions = transform.Find("CardPositions").GetComponent<CardPositions>();
        Debug.Log(transform.name + ": LoadDeskPositions", gameObject);
    }

    protected virtual void SpawmCards()
    {
        this.mainDesk = this.SpawmDesk(this.cardManager.MainCards, this.cardPositions.mainDeskPos);
        this.summonDesk = this.SpawmDesk(this.cardManager.SummonCards, this.cardPositions.summonDeskPos);
    }

    protected virtual List<CardCtrl> SpawmDesk(List<Card> cardDesk, Transform deskPos)
    {
        int index = 0;
        Vector3 pos;
        List<CardCtrl> cards = new List<CardCtrl>();
        foreach (Card card in cardDesk)
        {
            pos = deskPos.position;
            pos.y = (index * 0.1f) + pos.y;
            index++;

            CardCtrl cardCtrl = CardSpawner.Instance.SpawnBySO(card.cardSO, pos);
            cardCtrl.cardMovement.FaceDown();
            cardCtrl.gameObject.SetActive(true);

            cards.Add(cardCtrl);
        }

        return cards;
    }

    public virtual void SendCard2Line(LineType lineType)
    {
        CardCtrl cardCtrl = this.WithdrawCard(lineType);
        cardCtrl.cardMovement.FaceUp();

        CardPosition cardPosition = this.cardPositions.GetAvailablePosition(lineType);
        if (cardPosition == null)
        {
            Debug.LogWarning("SendCard2Line: No more CardPosition at " + lineType.ToString());
            return;
        }

        cardPosition.Card = cardCtrl;
        cardCtrl.transform.position = cardPosition.transform.position;
    }

    protected virtual CardCtrl WithdrawCard(LineType lineType)
    {
        switch (lineType)
        {
            case LineType.backLine:
            case LineType.frontLine:
            case LineType.handCard:
                return this.mainDesk[0];
        }

        return null;
    }
}
