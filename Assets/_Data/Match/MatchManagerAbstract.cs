using UnityEngine;

public abstract class MatchManagerAbstract : SaiMonoBehaviour
{
    public MatchManager matchManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMatchManager();
    }

    protected virtual void LoadMatchManager()
    {
        if (this.matchManager != null) return;
        this.matchManager = transform.parent.GetComponent<MatchManager>();
        Debug.Log(transform.name + ": LoadMatchManager", gameObject);
    }
}
