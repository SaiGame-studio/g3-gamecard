using System.Collections.Generic;
using UnityEngine;

public class MatchManager : SaiMonoBehaviour
{
    protected static MatchManager instance;
    public static MatchManager Instance { get => instance; }

    private Vector3 offCamPosition = new Vector3(0,1000,0);

    public CardCtrl cardAttacking;
    public Transform cardAttackingMarker;

    public CardCtrl cardChoose;

    public ManagerDesk currentDesk;
    public Transform currentDeskMarker;

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

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.ShowCurrentDeskMarker();
        this.ShowCardAttackingMarker();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCurrentDeskMarker();
        this.LoadCardAttackingMarker();
    }

    protected virtual void LoadCurrentDeskMarker()
    {
        if (this.currentDeskMarker != null) return;
        this.currentDeskMarker = transform.Find("CurrentDeskMarker");
        Debug.Log(transform.name + " LoadCurrentDeskMarker", gameObject);
    }

    protected virtual void LoadCardAttackingMarker()
    {
        if (this.cardAttackingMarker != null) return;
        this.cardAttackingMarker = transform.Find("CardAttackingMarker");
        Debug.Log(transform.name + " LoadCardAttackingMarker", gameObject);
    }

    protected virtual void ShowCurrentDeskMarker()
    {
        Vector3 pos = this.offCamPosition;
        if (this.currentDesk != null)
        {
            pos = this.currentDesk.cardPositions.mainDeskPos.position;
        }
        pos.y += 4;
        this.currentDeskMarker.position = pos;
    }

    protected virtual void ShowCardAttackingMarker()
    {
        Vector3 pos = this.offCamPosition;
        if (this.cardAttacking != null)
        {
            pos = this.cardAttacking.transform.position;
        }
        pos.y += 4;
        this.cardAttackingMarker.position = pos;
    }

    public virtual CardCtrl ChooseCard(CardCtrl cardCtrl)
    {
        this.cardChoose = cardCtrl;
        return this.cardChoose;
    }

    public virtual CardCtrl SetCardAttacking(CardCtrl cardCtrl)
    {
        List<LineType> attackLines = new List<LineType>
        {
            LineType.FrontLines,
            LineType.BackLines
        };

        if (!attackLines.Contains(cardCtrl.cardPosition.LineType)) return null;

        this.cardAttacking = cardCtrl;
        return this.cardAttacking;
    }

    public virtual bool IsCurrentDesk(ManagerDesk checkDesk)
    {
        return this.currentDesk == checkDesk;
    }

    public virtual bool IsCardAttacking(CardCtrl cardCtrl)
    {
        //if (this.cardAttacking == null) return true;
        return this.cardAttacking == cardCtrl;
    }

    public virtual void ChangeDesk(ManagerDesk newDesk)
    {
        this.cardChoose = null;
        this.currentDesk = newDesk;
    }
}
