using System.Collections.Generic;
using UnityEngine;

public class UIPickEnemyFrontLine : SaiMonoBehaviour
{
    public virtual void OnClick()
    {
        ManagerEnemyDesk.Instance.SendCard2Line(LineType.frontLine);
    }
}
