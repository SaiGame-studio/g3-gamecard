using System.Collections.Generic;
using UnityEngine;

public abstract class ManagerDesk : SaiMonoBehaviour
{
    [SerializeField] protected int cardPerLine = 5;

    [SerializeField] protected CardPositions cardPositions;

    [SerializeField] protected CardManager cardManager;
    [SerializeField] protected List<CardCtrl> mainDesk;
    [SerializeField] protected List<CardCtrl> summonDesk;

    [SerializeField] protected List<CardCtrl> handCards;
    [SerializeField] protected List<CardCtrl> frontCards;
    [SerializeField] protected List<CardCtrl> backCards;

    public List<CardCtrl> MainDesk { get => mainDesk; }
    public List<CardCtrl> SummonDesk { get => summonDesk; }

    public List<CardCtrl> HandCards { get => handCards; }
    public List<CardCtrl> FrontCards { get => frontCards; }
    public List<CardCtrl> BackCards { get => backCards; }

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

    public virtual void WithdrawCard()
    {
        if (this.handCards.Count >= this.cardPerLine)
        {
            Debug.LogWarning("WithdrawCard: Hand Card Max " + this.cardPerLine.ToString(), gameObject);
            return;
        }

        int index = 0;
        CardCtrl cardCtrl = this.mainDesk[index];
        this.mainDesk.RemoveAt(index);

        this.handCards.Add(cardCtrl);

        this.SendCardObj2Line(cardCtrl, LineType.handCard);
    }

    public virtual void SendHandCard2Line(int index)
    {
        if (handCards.Count <= 0)
        {
            Debug.LogWarning("SendCard2Line: No more Card Hand", gameObject);
            return;
        }

        LineType lineType = LineType.frontLine;
        List<CardCtrl> newLine = this.frontCards;

        CardCtrl cardCtrl = this.handCards[index];
        if (cardCtrl.cardData.CardSO.cardType == CardType.spell)
        {
            newLine = this.backCards;
            lineType = LineType.backLine;
        }

        if (newLine.Count >= this.cardPerLine)
        {
            Debug.LogWarning("SendCard2Line: Card Max in Line " + this.cardPerLine.ToString(), gameObject);
            return;
        }

        this.handCards.RemoveAt(index);

        cardCtrl.cardPosition.RemoveCard();

        newLine.Add(cardCtrl);
        this.SendCardObj2Line(cardCtrl, lineType);
    }

    public virtual void Line2Desk(LineType currentLineType, int cardIndex, LineType targetLineType)
    {
        List<CardCtrl> currentLine = this.Type2Line(currentLineType);
        if (currentLine.Count <= 0)
        {
            Debug.LogWarning("Line2Desk: Line has no Card "+ currentLineType.ToString(), gameObject);
            return;
        }

        CardCtrl cardCtrl = currentLine[cardIndex];
        currentLine.RemoveAt(cardIndex);
        cardCtrl.cardPosition.RemoveCard();

        this.CardBackToDesk(cardCtrl, targetLineType);
    }

    protected virtual void CardBackToDesk(CardCtrl cardCtrl, LineType lineType)
    {
        List<CardCtrl> line = this.Type2Line(lineType);
        line.Add(cardCtrl);
        cardCtrl.cardMovement.FaceDown();
        cardCtrl.transform.position = this.cardPositions.mainDeskPos.position;
    }

    protected virtual List<CardCtrl> Type2Line(LineType lineType)
    {
        if (lineType == LineType.frontLine) return this.frontCards;
        if (lineType == LineType.backLine) return this.backCards;
        if (lineType == LineType.mainDesk) return this.mainDesk;
        if (lineType == LineType.summonDesk) return this.summonDesk;
        return null;
    }


    protected virtual void SendCardObj2Line(CardCtrl cardCtrl, LineType lineType)
    {
        cardCtrl.cardMovement.FaceUp();//TODO: for testing, need to remove

        CardPosition cardPosition = this.cardPositions.GetAvailablePosition(lineType);
        if (cardPosition == null)
        {
            Debug.LogWarning("SendCard2Line: No more CardPosition at " + lineType.ToString());
            return;
        }

        cardPosition.Card = cardCtrl;
        cardCtrl.transform.position = cardPosition.transform.position;

        cardCtrl.cardPosition = cardPosition;
    }

}
