using System.Collections.Generic;
using UnityEngine;

public class UIPickMyBackLine : SaiMonoBehaviour
{
    public virtual void OnClick()
    {
        MatchManager.Instance.SendCard2Line(LineType.myBackLine);
    }
}
