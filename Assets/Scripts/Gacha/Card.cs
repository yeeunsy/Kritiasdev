using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardGrade { SSS, SS, S, A, B, F} //열거형 카드 등급 (타워등급)

[System.Serializable]
public class Card
{
    public string cardName;
    public Sprite cardImage;
    public CardGrade cardGrade;
    public int weight;

    public Card(Card card)
    {
        this.cardName = card.cardName;
        this.cardImage = card.cardImage;
        this.cardGrade = card.cardGrade;
        this.weight = card.weight;
    }

}
