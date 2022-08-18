using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardManager : SaiMonoBehaviour
{
    [Header("Desk Manager")]
    [SerializeField] protected CardManagerData cardManagerData;
    [SerializeField] protected CardSpawner cardSpawner;
    [SerializeField] protected List<Card> mainCards;
    [SerializeField] protected List<Card> summonCards;
    [SerializeField] protected List<Card> notUseCards;

    public List<Card> MainCards { get => mainCards; }
    public List<Card> SummonCards { get => summonCards; }
    public List<Card> NotUseCards { get => notUseCards; }

    protected override void Awake()
    {
        base.Awake();
        //this.CreateTestMainDesk();//TODO: for testing only
        //this.cardManagerData.LoadData(this);
        this.LoadDataSO();
    }

    protected virtual void LoadDataSO()
    {
        this.mainCards = this.cardManagerData.mainCards;
        this.summonCards = this.cardManagerData.summonCards;
        this.notUseCards = this.cardManagerData.notUseCards;
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCardSpawner();
        this.LoadCardManagerData();
    }

    protected abstract void LoadCardManagerData();

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

        if (cardSO.cardType == CardType.summon) return this.CardDeskAdd(cardSO, this.SummonCards, addCount);
        return this.CardDeskAdd(cardSO, this.MainCards, addCount);
    }

    protected virtual bool CardDeskAdd(CardSO cardSO, List<Card> cardDesk, int addCount = 1)
    {
        int cardCount = this.CardDeskCount(cardSO.cardID, cardDesk);
        int newCardCount = cardCount + addCount;

        if (newCardCount > cardSO.maxInDesk)
        {
            this.CardDeskAdd(cardSO, this.notUseCards, addCount);
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
        foreach (Card card in this.MainCards)
        {
            if (card.cardID == cardID) return card;
        }

        return null;
    }

    public virtual Card SummonDeskGet(CardID cardID)
    {
        foreach (Card card in this.SummonCards)
        {
            if (card.cardID == cardID) return card;
        }

        return null;
    }
}
