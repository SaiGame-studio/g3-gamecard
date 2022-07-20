using System;
using UnityEngine;

[Serializable]
public class Card
{
    public string name;
    public CardID cardID;
    public CardSO cardSO;
    public int useCount = 0;
}
