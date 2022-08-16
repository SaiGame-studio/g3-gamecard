using System.Collections.Generic;
using UnityEngine;

public class MatchManager : SaiMonoBehaviour
{
    protected static MatchManager instance;
    public static MatchManager Instance { get => instance; }
    public CardCtrl cardChoose;
    public ManagerDesk currentDesk;

    protected override void Awake()
    {
        base.Awake();
        if (MatchManager.instance != null) Debug.LogError("Only 1 MatchManager allow");
        MatchManager.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.currentDesk = ManagerMyDesk.Instance;
    }

    public virtual CardCtrl ChooseCard(CardCtrl cardCtrl)
    {
        this.cardChoose = cardCtrl;
        return this.cardChoose;
    }

    public virtual bool IsCurrentDesk(ManagerDesk checkDesk)
    {
        return this.currentDesk == checkDesk;
    }

    public virtual void ChangeDesk(ManagerDesk newDesk)
    {
        this.cardChoose = null;
        this.currentDesk = newDesk;
    }
}
