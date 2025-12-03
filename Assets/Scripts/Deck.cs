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

    public int Count
    {
        get
        {
            return this.cards.Count;
        }
    }

    private void freshDeck()
    {
        this.cards = new List<Card>();
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

    public void reset()
    {
        freshDeck();
    }
    public Card draw()
    {
        if (this.cards.Count > 1)
        {
            Card card = this.cards[0];
            this.cards.RemoveAt(0);
            return card;
        }
        return new Card("INVALID", 0);
    }
    public Deck()
    {
        freshDeck();
    }

}
