using System.Collections.Generic;
using UnityEngine;

public class UIPickEnemyTurn : SaiMonoBehaviour
{
    public virtual void OnClick()
    {
        MatchManager.Instance.ChangeDesk(ManagerEnemyDesk.Instance);
    }
}
