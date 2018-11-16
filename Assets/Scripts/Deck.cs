using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck {

    private List<Card.Data> cardDataList;

    public void Initialize() {
        cardDataList = new List<Card.Data>();
        foreach (Suit suit in System.Enum.GetValues(typeof(Suit))) {
            for (int i = 1; i <= 13; ++i) {
                int power = i > 10 ? 10 : i;
                var cardData = new Card.Data(suit, i, power);
                cardDataList.Add(cardData);
            }
        }

        Shuffle();
    }

    public void Shuffle() {
        for (int i = 0; i < cardDataList.Count; ++i) {
            int rand = Random.Range(0, cardDataList.Count);
            var tmp = cardDataList[i];
            cardDataList[i] = cardDataList[rand];
            cardDataList[rand] = tmp;
        }
    }

    public Card.Data Draw() {
        var cardData = cardDataList[0];
        cardDataList.RemoveAt(0);
        return cardData;
    }
}
