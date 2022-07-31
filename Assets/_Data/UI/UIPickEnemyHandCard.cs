using System.Collections.Generic;
using UnityEngine;

public class UIPickEnemyHandCard : SaiMonoBehaviour
{
    public virtual void OnClick()
    {
        ManagerEnemyDesk.Instance.SendCard2Line(LineType.handCard);
    }
}
