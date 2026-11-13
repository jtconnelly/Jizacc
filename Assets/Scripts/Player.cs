using System.Collections.Generic;

public class Player
{
    private List<SabaccCard> hand;

    public Player()
    {
        hand = new List<SabaccCard>();
    }

    public List<SabaccCard> GetHand()
    {
        return hand;
    }

    public void AddCardToHand(SabaccCard card)
    {
        hand.Add(card);
    }

    public void RemoveCardFromHand(SabaccCard card)
    {
        hand.Remove(card);
    }
}