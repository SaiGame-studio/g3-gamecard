using System.Collections.Generic;
using UnityEngine;

public class MatchManager : SaiMonoBehaviour
{
    private static MatchManager instance;
    public static MatchManager Instance { get => instance; }

    [SerializeField] protected MyDesk myDesk;
    [SerializeField] protected EnemyDesk enemyDesk;

    [SerializeField] protected DeskPositions deskPositions;
    [SerializeField] protected List<CardCtrl> myCard;
    [SerializeField] protected List<CardCtrl> enemyCard;

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
        this.myDesk = GameObject.Find("MyDesk").GetComponent<MyDesk>();
        Debug.Log(transform.name + ": LoadMyDesk", gameObject);
    }

    protected virtual void LoadEnemyDesk()
    {
        if (this.enemyDesk != null) return;
        this.enemyDesk = GameObject.Find("EnemyDesk").GetComponent<EnemyDesk>();
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
        this.SpawmDesk(this.myDesk.MainDesk, this.deskPositions.myDeskPos);
        this.SpawmDesk(this.myDesk.SummonDesk, this.deskPositions.mySummonPos);

        this.SpawmDesk(this.enemyDesk.MainDesk, this.deskPositions.enemyDeskPos);
        this.SpawmDesk(this.enemyDesk.SummonDesk, this.deskPositions.enemySummonPos);
    }

    protected virtual void SpawmDesk(List<Card> cardDesk,Transform deskPos)
    {
        int index = 0;
        Vector3 pos;
        foreach (Card card in cardDesk)
        {
            pos = deskPos.position;
            pos.y = (index * 0.1f) + pos.y;
            index++;

            CardCtrl cardCtrl = CardSpawner.Instance.SpawnBySO(card.cardSO, pos);
            cardCtrl.cardMovement.FaceDown();
            cardCtrl.gameObject.SetActive(true);
        }
    }
}
