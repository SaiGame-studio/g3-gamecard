using System.Collections.Generic;
using UnityEngine;

public class UIPickEnemyBackLine : SaiMonoBehaviour
{
    public virtual void OnClick()
    {
        ManagerEnemyDesk.Instance.SendCard2Line(LineType.backLine);
    }
}
