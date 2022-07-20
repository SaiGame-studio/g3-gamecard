using System;
using System.Collections.Generic;
using UnityEngine;

public class DeskManager : SaiMonoBehaviour
{
    [Header("Desk Manager")]
    [SerializeField] protected int mainDeskCount = 0;
    [SerializeField] protected List<Card> mainDesk;

    [SerializeField] protected int summonDeskCount = 0;
    [SerializeField] protected List<Card> summonDesk;

    protected override void Start()
    {
        base.Start();
        this.CreateTestMainDesk();//TODO: for testing only
    }

    /// <summary>
    /// For testing only
    /// </summary>
    protected virtual void CreateTestMainDesk()
    {
        foreach (CardID cardID in Enum.GetValues(typeof(CardID)))
        {
            CardSO cardSO = CardSpawner.Instance.GetSOByID(cardID);
            this.Add(cardID, cardSO.maxInDesk);
        }
    }

    public virtual bool Add(CardID cardID, int addCount = 1)
    {
        CardSO cardSO = CardSpawner.Instance.GetSOByID(cardID);
        if (cardSO == null) return false;

        if (cardSO.cardType == CardType.summon) return this.SummonDeskAdd(cardSO, addCount);
        return this.MainDeskAdd(cardSO, addCount);
    }

    protected virtual bool SummonDeskAdd(CardSO cardSO, int addCount = 1)
    {
        CardID cardID = cardSO.cardID;

        Card card = this.SummonDeskGet(cardID);
        if (card == null)
        {
            card = new Card
            {
                cardID = cardID,
                cardSO = cardSO
            };

            this.summonDesk.Add(card);
        }

        int newCount = card.cardCount + addCount;
        if (newCount > cardSO.maxInDesk)
        {
            Debug.LogWarning(cardSO.cardName + ": Card Count already max");
            return false;
        }

        card.cardCount = newCount;
        this.summonDeskCount += addCount;
        return true;
    }

    protected virtual bool MainDeskAdd(CardSO cardSO, int addCount = 1)
    {
        CardID cardID = cardSO.cardID;

        Card card = this.MainDeskGet(cardID);
        if (card == null)
        {
            card = new Card
            {
                cardID = cardID,
                cardSO = cardSO
            };

            this.mainDesk.Add(card);
        }

        int newCount = card.cardCount + addCount;
        if (newCount > cardSO.maxInDesk)
        {
            Debug.LogWarning(cardSO.cardName + ": Card Count already max");
            return false;
        }

        card.cardCount = newCount;
        this.mainDeskCount += addCount;
        return true;
    }

    public virtual Card MainDeskGet(CardID cardID)
    {
        foreach (Card card in this.mainDesk)
        {
            if (card.cardID == cardID) return card;
        }

        return null;
    }

    public virtual Card SummonDeskGet(CardID cardID)
    {
        foreach (Card card in this.summonDesk)
        {
            if (card.cardID == cardID) return card;
        }

        return null;
    }
}
