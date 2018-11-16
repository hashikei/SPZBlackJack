using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    public struct Data
    {
        public Suit suit;
        public int number;
        public int power;

        public Data(Suit suit, int number, int power) {
            this.suit = suit;
            this.number = number;
            this.power = power;
        }
    }

    [SerializeField] private Text suitText;
    [SerializeField] private Text numberText;

    public Data data { get; private set; }

    public void Initialize(Data _data) {
        data = _data;

        suitText.text = data.suit.ToString();
        numberText.text = data.number.ToString();
    }

    public void Reverse() {
        suitText.enabled = !suitText.enabled;
        numberText.enabled = !numberText.enabled;
    }
}
