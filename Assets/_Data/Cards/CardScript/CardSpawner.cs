using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : SaiMonoBehaviour
{
    private static CardSpawner instance;
    public static CardSpawner Instance { get => instance; }

    [SerializeField] protected Transform cardHolder;
    [SerializeField] protected GameObject cardPrefab;
    [SerializeField] protected List<CardSO> cardDatas;

    protected override void Awake()
    {
        base.Awake();
        if (CardSpawner.instance != null) Debug.LogError("Only 1 CardDataManager allow");
        CardSpawner.instance = this;

        this.HidePrefabs();
    }

    protected override void Start()
    {
        base.Start();
        this.TestLoadCards();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCardHolder();
        this.LoadCardPrefab();
        this.LoadCardDatas();
    }

    protected virtual void LoadCardPrefab()
    {
        if (this.cardPrefab != null) return;
        this.cardPrefab = transform.Find("CardPrefab").gameObject;
        Debug.Log(transform.name + ": LoadCardPrefab", gameObject);
    }

    protected virtual void LoadCardHolder()
    {
        if (this.cardHolder != null) return;
        this.cardHolder = GameObject.Find("CardHolder").transform;
        Debug.Log(transform.name + ": LoadCardHolder", gameObject);
    }

    protected virtual void LoadCardDatas()
    {
        if (this.cardDatas.Count > 0) return;
        CardSO[] cardDatas = Resources.FindObjectsOfTypeAll(typeof(CardSO)) as CardSO[];

        foreach (CardSO cardData in cardDatas)
        {
            this.cardDatas.Add(cardData);
        }

        Debug.Log(transform.name + ": LoadCardDatas", gameObject);
    }

    /// <summary>
    /// For testing only, will be removed 
    /// </summary>
    protected virtual void TestLoadCards()
    {
        int index = 0;
        foreach(CardSO cardSO in this.cardDatas)
        {
            index++;
            Vector3 pos = this.cardPrefab.transform.position;
            pos.x = (12 * -index)+25;

            CardCtrl cardCtrl = this.SpawnBySO(cardSO, pos);
            cardCtrl.gameObject.SetActive(true);
        }
    }

    protected virtual void HidePrefabs()
    {
        this.cardPrefab.gameObject.SetActive(false);
    }

    public virtual CardSO GetSOByID(CardID cardID)
    {
        foreach(CardSO cardSO in this.cardDatas)
        {
            if (cardSO.cardID == cardID) return cardSO;
        }

        Debug.LogWarning("CardID exist without CardSO: This should not happen");
        return null;
    }

    public virtual CardCtrl SpawnBySO(CardSO cardSO, Vector3 spawnPos)
    {
        GameObject newCard = Instantiate(this.cardPrefab);
        newCard.name = cardSO.name;
        newCard.transform.position = spawnPos;
        newCard.transform.parent = this.cardHolder;

        CardCtrl cardCtrl = newCard.GetComponent<CardCtrl>();
        cardCtrl.cardData.SetSO(cardSO);

        return cardCtrl;
    }
}
