using System.Collections.Generic;

public class IDeck
{
    static protected List<ICard> cards;
    protected Stack<ICard> deck;
    public void Shuffle()
    {
        deck = cards.Shuffle().ToStack();
    }

    public ICard Draw()
    {
        if (deck.Count == 0)
        {
            throw new System.InvalidOperationException("The deck is empty.");
        }
        return deck.Pop();
    }

    public void ResetDeck()
    {
        deck.Clear();
        Shuffle();
    }

}