using System.Collections.Generic;
using UnityEngine;

public class UIPickEnemyCard2Line : SaiMonoBehaviour
{
    public virtual void OnClick()
    {
        ManagerEnemyDesk.Instance.SendHandCard2Line(0);
    }
}
