using System.Collections.Generic;

using UnityEngine;

public class Card
{
    string suit;
    int value;
    public Card(string suit, int val)
    {
        this.suit = suit;
        this.value = val;
    }
}
public class Deck
{
    List<Card> cards;

    public void shuffle()
    {
        int n = this.cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Card value = this.cards[k];
            this.cards[k] = this.cards[n];
            this.cards[n] = value;
        }
    }
    public Deck()
    {
        for (int i = 1; i <= 10; i++)
        {
            cards.Add(new Card("Triangle", i));
            cards.Add(new Card("Circle", i));
            cards.Add(new Card("Square", i));
            cards.Add(new Card("Triangle", -i));
            cards.Add(new Card("Circle", -i));
            cards.Add(new Card("Square", -i));
        }
        cards.Add(new Card("Zero", 0));
        cards.Add(new Card("Zero", 0));
        shuffle();
    }

}
