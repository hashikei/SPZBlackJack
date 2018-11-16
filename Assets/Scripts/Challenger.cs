using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Challenger : MonoBehaviour {

    public int point {
        get {
            int _point = 0;
            int aceCount = 0;
            foreach(var card in cardList) {
                _point += card.data.power;
                if (card.data.number == 1) {
                    ++aceCount;
                }
            }
            if (aceCount > 0) {
                for (int i = 0; i < aceCount; ++i) {
                    if (_point > 10) {
                        break;
                    }

                    _point += 10;
                }
            }
            return _point;
        }
    }
    public bool isBust { get { return point > Config.BUST; } }

    protected List<Card> cardList = new List<Card>();

    public virtual void Draw(Card prefab, Deck deck) {
        var card = Instantiate(prefab, transform, false);
        card.Initialize(deck.Draw());

        cardList.Add(card);
    }
}
