using System.Collections.Generic;
using UnityEngine;

public class UIPickMyFrontLine : SaiMonoBehaviour
{
    public virtual void OnClick()
    {
        ManagerMyDesk.Instance.SendCard2Line(LineType.frontLine);
    }
}
