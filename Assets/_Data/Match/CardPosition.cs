using System;
using UnityEngine;
using System.Collections;

public class CardPosition : SaiMonoBehaviour
{
    [SerializeField] protected CardCtrl card;
    public CardCtrl Card { get => card; set => card = value; }

    public virtual bool IsAvailable()
    {
        return card == null;
    }
}
