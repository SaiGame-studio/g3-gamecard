using System.Collections.Generic;
using UnityEngine;

public class MatchManager : SaiMonoBehaviour
{
    private static MatchManager instance;
    public static MatchManager Instance { get => instance; }

    [SerializeField] protected MyCards myDesk;
    [SerializeField] protected EnemyCards enemyDesk;

    [SerializeField] protected DeskPositions deskPositions;

    [SerializeField] protected List<CardCtrl> myMainDesk;
    [SerializeField] protected List<CardCtrl> mySummonDesk;

    [SerializeField] protected List<CardCtrl> enemyMainDesk;
    [SerializeField] protected List<CardCtrl> enemySummonDesk;

    protected override void Awake()
    {
        base.Awake();
        if (MatchManager.instance != null) Debug.LogError("Only 1 MatchManager allow");
        MatchManager.instance = this;
    }

    protected override void Start()
    {
        this.SpawmCards();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMyDesk();
        this.LoadEnemyDesk();
        this.LoadDeskPositions();
    }

    protected virtual void LoadMyDesk()
    {
        if (this.myDesk != null) return;
        this.myDesk = GameObject.Find("MyCards").GetComponent<MyCards>();
        Debug.Log(transform.name + ": LoadMyDesk", gameObject);
    }

    protected virtual void LoadEnemyDesk()
    {
        if (this.enemyDesk != null) return;
        this.enemyDesk = GameObject.Find("EnemyCards").GetComponent<EnemyCards>();
        Debug.Log(transform.name + ": LoadEnemyDesk", gameObject);
    }

    protected virtual void LoadDeskPositions()
    {
        if (this.deskPositions != null) return;
        this.deskPositions = transform.Find("DeskPositions").GetComponent<DeskPositions>();
        Debug.Log(transform.name + ": LoadDeskPositions", gameObject);
    }

    protected virtual void SpawmCards()
    {
        this.myMainDesk = this.SpawmDesk(this.myDesk.MainCards, this.deskPositions.MyDeskPos);
        this.mySummonDesk = this.SpawmDesk(this.myDesk.SummonCards, this.deskPositions.MySummonPos);

        this.enemyMainDesk = this.SpawmDesk(this.enemyDesk.MainCards, this.deskPositions.EnemyDeskPos);
        this.enemySummonDesk = this.SpawmDesk(this.enemyDesk.SummonCards, this.deskPositions.EnemySummonPos);
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

        CardPosition cardPosition = this.deskPositions.GetAvailablePosition(lineType);
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
            case LineType.myBackLine:
            case LineType.myFrontLine:
                return this.myMainDesk[0];

            case LineType.enemyBackLine:
            case LineType.enemyFrontLine:
                return this.enemyMainDesk[0];
        }

        return null;
    }
}
