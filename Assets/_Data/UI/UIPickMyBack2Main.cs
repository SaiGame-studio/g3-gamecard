using System.Collections.Generic;
using UnityEngine;

public class UIPickMyBack2Main : SaiMonoBehaviour
{
    public virtual void OnClick()
    {
        ManagerMyDesk.Instance.Line2Desk(LineType.backLine, 0, LineType.mainDesk);
    }
}
