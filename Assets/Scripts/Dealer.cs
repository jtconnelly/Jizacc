using System.Collections.Generic;
using UnityEngine;

public class Dealer
{
    private IDeck deck;
    private Stack<ICard> discardPile;

    public Dealer(IDeck deck)
    {
        this.deck = deck;
        discardPile = new Stack<ICard>();
    }

    public ICard DrawCard()
    {
        return deck.Draw();
    }

    public void DiscardCard(ICard card)
    {
        discardPile.Push(card);
    }
    
}
