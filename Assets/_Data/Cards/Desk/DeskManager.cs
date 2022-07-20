using System;
using System.Collections.Generic;
using UnityEngine;

public class DeskManager : SaiMonoBehaviour
{
    [Header("Desk Manager")]
    [SerializeField] protected CardSpawner cardSpawner;
    [SerializeField] protected List<Card> mainDesk;
    [SerializeField] protected List<Card> summonDesk;
    [SerializeField] protected List<Card> notUseDesk;

    public List<Card> MainDesk { get => mainDesk; }
    public List<Card> SummonDesk { get => summonDesk; }

    protected override void Awake()
    {
        base.Awake();
        this.CreateTestMainDesk();//TODO: for testing only
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCardSpawner();
    }

    protected virtual void LoadCardSpawner()
    {
        if (this.cardSpawner != null) return;
        this.cardSpawner = GameObject.Find("CardSpawner").GetComponent<CardSpawner>();
        Debug.Log(transform.name + ": LoadCardSpawner", gameObject);
    }

    /// <summary>
    /// For testing only
    /// </summary>
    protected virtual void CreateTestMainDesk()
    {
        foreach (CardID cardID in Enum.GetValues(typeof(CardID)))
        {
            CardSO cardSO = this.cardSpawner.GetSOByID(cardID);
            this.Add(cardID, cardSO.maxInDesk);
        }

        this.Add(CardID.Mikasa_2, 1);
        this.Add(CardID.Pikachu_0, 1);
    }

    public virtual bool Add(CardID cardID, int addCount = 1)
    {
        CardSO cardSO = this.cardSpawner.GetSOByID(cardID);
        if (cardSO == null) return false;

        if (cardSO.cardType == CardType.summon) return this.CardDeskAdd(cardSO, this.SummonDesk, addCount);
        return this.CardDeskAdd(cardSO, this.MainDesk, addCount);
    }

    protected virtual bool CardDeskAdd(CardSO cardSO, List<Card> cardDesk, int addCount = 1)
    {
        int cardCount = this.CardDeskCount(cardSO.cardID, cardDesk);
        int newCardCount = cardCount + addCount;

        if (newCardCount > cardSO.maxInDesk)
        {
            this.CardDeskAdd(cardSO, this.notUseDesk, addCount);
            return false;
        }

        Card card = card = new Card
        {
            name = cardSO.cardName,
            cardID = cardSO.cardID,
            cardSO = cardSO
        };

        for (int i = 0; i < addCount; i++)
        {
            cardDesk.Add(card);
        }

        return true;
    }

    protected virtual int CardDeskCount(CardID cardID, List<Card> cardDesk)
    {
        int count = 0;
        foreach (Card card in cardDesk)
        {
            if (card.cardID == cardID) count++;
        }
        return count;
    }

    public virtual Card MainDeskGet(CardID cardID)
    {
        foreach (Card card in this.MainDesk)
        {
            if (card.cardID == cardID) return card;
        }

        return null;
    }

    public virtual Card SummonDeskGet(CardID cardID)
    {
        foreach (Card card in this.SummonDesk)
        {
            if (card.cardID == cardID) return card;
        }

        return null;
    }
}
