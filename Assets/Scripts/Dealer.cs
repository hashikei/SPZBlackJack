using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dealer : Challenger {

    public Card reverseCard { get; private set; }

    public void DrawReverse(Card prefab, Deck deck) {
        Draw(prefab, deck);

        reverseCard = cardList.Last();
        reverseCard.Reverse();
    }
}
