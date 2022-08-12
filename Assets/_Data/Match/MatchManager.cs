using System.Collections.Generic;
using UnityEngine;

public class MatchManager : SaiMonoBehaviour
{
    private static MatchManager instance;
    public static MatchManager Instance { get => instance; }
    public CardCtrl cardChoose;

    protected override void Awake()
    {
        base.Awake();
        if (MatchManager.instance != null) Debug.LogError("Only 1 MatchManager allow");
        MatchManager.instance = this;
    }

    public virtual CardCtrl ChooseCard(CardCtrl cardCtrl)
    {
        this.cardChoose = cardCtrl;
        return this.cardChoose;
    }
}
