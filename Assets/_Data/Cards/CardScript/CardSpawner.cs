using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : SaiMonoBehaviour
{
    private static CardSpawner instance;
    public static CardSpawner Instance { get => instance; }

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
        this.LoadCardPrefab();
        this.LoadCardDatas();
    }

    protected virtual void LoadCardPrefab()
    {
        if (this.cardPrefab != null) return;
        this.cardPrefab = transform.Find("CardPrefab").gameObject;
        Debug.Log(transform.name + ": LoadCardPrefab", gameObject);
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

    protected virtual void TestLoadCards()
    {
        foreach(CardSO cardSO in this.cardDatas)
        {
            GameObject newCard = Instantiate(this.cardPrefab);
            CardCtrl cardCtrl = newCard.GetComponent<CardCtrl>();
            cardCtrl.cardData.SetSO(cardSO);

            newCard.name = cardSO.name;
            newCard.SetActive(true);
        }
    }

    protected virtual void HidePrefabs()
    {
        this.cardPrefab.gameObject.SetActive(false);
    }
}
