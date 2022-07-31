using System.Collections.Generic;
using UnityEngine;

public class UIPickEnemyBackLine : SaiMonoBehaviour
{
    public virtual void OnClick()
    {
        MatchManager.Instance.SendCard2Line(LineType.enemyBackLine);
    }
}
