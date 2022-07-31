using System.Collections.Generic;
using UnityEngine;

public class UIPickEnemyFrontLine : SaiMonoBehaviour
{
    public virtual void OnClick()
    {
        MatchManager.Instance.SendCard2Line(LineType.enemyFrontLine);
    }
}
