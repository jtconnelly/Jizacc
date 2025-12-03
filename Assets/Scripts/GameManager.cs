using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Showdown: When all cards should be shown face up
    public bool showdown = false;
    public int Die1, Die2;
    private uint roundCounter = 1;
    private CardMatTranslate cardGetter = CardMatTranslate.Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void rollDice()
    {
        Die1 = Random.Range(1, 7);
        Die2 = Random.Range(1, 7);
    }
    void finishRound()
    {
        rollDice();
        if (Die1 == Die2)
        {
            // all players discard, keep track of how many
            // redeal the amount of discarded cards to each player 
            // ie. P1 discards 4, deal back 4
        }
        ++roundCounter;
        if (roundCounter > 3)
        {
            // Game Finish
            showdown = true;
            // calculate winner
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
