using System.Collections.Generic;
using UnityEngine;

public class UIPickMyCard : SaiMonoBehaviour
{
    public virtual void OnClick()
    {
        //ManagerMyDesk.Instance.SendCard2Line(LineType.handCard);
        ManagerMyDesk.Instance.WithdrawCard();
    }
}
