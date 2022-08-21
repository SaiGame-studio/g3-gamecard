using System.Collections.Generic;
using UnityEngine;

public class TargetMarkers : MatchManagerAbstract
{
    private Vector3 offCamPosition = new Vector3(0, 1000, 0);
    public List<Transform> targerMakers;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.ShowTargetMarkers();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTargetMarkers();
    }

    protected virtual void LoadTargetMarkers()
    {
        if (this.targerMakers.Count > 0) return;

        foreach (Transform target in transform)
        {
            this.targerMakers.Add(target);
        }
        Debug.Log(transform.name + ": LoadTargetMarkers", gameObject);
    }

    public virtual void ShowTargetMarkers()
    {
        if (this.matchManager.cardAttacking == null)
        {
            this.ClearMarkers();
            return;
        }
        List<CardCtrl> targets = this.matchManager.cardAttacking.cardAction.cardSkill.Targets;
        if (targets.Count == 0)
        {
            this.ClearMarkers();
            return;
        }

        int index = 0;
        Transform targetmarker;
        foreach (CardCtrl cardCtrl in targets)
        {
            targetmarker = this.targerMakers[index];
            targetmarker.position = cardCtrl.transform.position;
            index++;
        }
    }

    protected virtual void ClearMarkers()
    {
        foreach(Transform marker in this.targerMakers)
        {
            marker.position = this.offCamPosition;
        }
    }
}
