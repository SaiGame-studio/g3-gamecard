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
        this.MoveMyCardToTest();
        this.MoveEnemyCardToTest();
    }

    protected virtual void MoveMyCardToTest()
    {
        int cardCount = 0;
        CardCtrl cardCtrl;

        foreach (Transform cardPos in this.deskPositions.myBackLines)
        {
            cardCtrl = this.GetMyMainCard(cardCount);
            cardCtrl.transform.position = cardPos.position;
            cardCtrl.cardMovement.ToHorizontal();
            //cardCtrl.cardMovement.FaceUp();

            cardCount++;
        }

        foreach (Transform cardPos in this.deskPositions.myFrontLines)
        {
            cardCtrl = this.GetMyMainCard(cardCount);
            cardCtrl.transform.position = cardPos.position;
            cardCtrl.cardMovement.ToHorizontal();
            cardCtrl.cardMovement.FaceUp();

            cardCount++;
        }

        Invoke("MoveMyCardToTest", 1f);
    }

    protected virtual void MoveEnemyCardToTest()
    {
        int cardCount = 0;
        CardCtrl cardCtrl;

        foreach (Transform cardPos in this.deskPositions.enemyBackLines)
        {
            cardCtrl = this.GetEnemyMainCard(cardCount);
            cardCtrl.transform.position = cardPos.position;
            cardCtrl.cardMovement.ToHorizontal();
            //cardCtrl.cardMovement.FaceUp();

            cardCount++;
        }

        foreach (Transform cardPos in this.deskPositions.enemyFrontLines)
        {
            cardCtrl = this.GetEnemyMainCard(cardCount);
            cardCtrl.transform.position = cardPos.position;
            //cardCtrl.cardMovement.ToHorizontal();
            cardCtrl.cardMovement.FaceUp();

            cardCount++;
        }

        Invoke("MoveMyCardToTest", 1f);
    }


    protected virtual CardCtrl GetMyMainCard(int index)
    {
        return this.myMainDesk[index];
    }

    protected virtual CardCtrl GetEnemyMainCard(int index)
    {
        return this.enemyMainDesk[index];
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
        this.myMainDesk = this.SpawmDesk(this.myDesk.MainCards, this.deskPositions.myDeskPos);
        this.mySummonDesk = this.SpawmDesk(this.myDesk.SummonCards, this.deskPositions.mySummonPos);

        this.enemyMainDesk = this.SpawmDesk(this.enemyDesk.MainCards, this.deskPositions.enemyDeskPos);
        this.enemySummonDesk = this.SpawmDesk(this.enemyDesk.SummonCards, this.deskPositions.enemySummonPos);
    }

    protected virtual List<CardCtrl> SpawmDesk(List<Card> cardDesk,Transform deskPos)
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
}
