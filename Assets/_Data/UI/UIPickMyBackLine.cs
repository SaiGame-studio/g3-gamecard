using System.Collections.Generic;
using UnityEngine;

public class UIPickMyBackLine : SaiMonoBehaviour
{
    public virtual void OnClick()
    {
        ManagerMyDesk.Instance.SendCard2Line(LineType.backLine);
    }
}
