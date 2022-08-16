using System.Collections.Generic;
using UnityEngine;

public class UIPickMyTurn : SaiMonoBehaviour
{
    public virtual void OnClick()
    {
        MatchManager.Instance.ChangeDesk(ManagerMyDesk.Instance);
        
    }
}
