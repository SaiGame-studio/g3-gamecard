using System.Collections.Generic;
using UnityEngine;

public class UIPickMyCard2Line : SaiMonoBehaviour
{
    public virtual void OnClick()
    {
        ManagerMyDesk.Instance.SendHandCard2Line(0);
    }
}
