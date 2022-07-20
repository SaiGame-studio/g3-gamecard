using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CardData", order = 1)]
public class CardSO : ScriptableObject
{
    public CardID cardID;
    public string cardName;
    public CardType cardType;
    public string cardDescription;
    public Material image;

    public int attack = 1;
    public int defend = 1;

    public int maxInDesk = 3;
}
