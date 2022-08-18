using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CardManagerData")]
public class CardManagerData : ScriptableObject
{
    public List<Card> mainCards;
    public List<Card> summonCards;
    public List<Card> notUseCards;

    public virtual void LoadData(CardManager cardManager)
    {
        this.mainCards = cardManager.MainCards;
        this.summonCards = cardManager.SummonCards;
        this.notUseCards = cardManager.NotUseCards;
    }
}
