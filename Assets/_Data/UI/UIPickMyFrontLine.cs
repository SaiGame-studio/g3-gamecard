using System.Collections.Generic;
using UnityEngine;

public class UIPickMyFrontLine : SaiMonoBehaviour
{
    public virtual void OnClick()
    {
        MatchManager.Instance.SendCard2Line(LineType.myFrontLine);
    }
}
