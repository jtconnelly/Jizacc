using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardMatTranslate
{
    private static CardMatTranslate instance = null;

    // 61 since there are 2 zeros
    private Dictionary<Card, Material> cardToMat = new Dictionary<Card, Material>(61);

    private CardMatTranslate()
    {
        cardToMat.Add(new Card("Zero", 0), Resources.Load<Material>("Cards/Materials/Zero"));
        for (int i = 1; i < 10; ++i)
        {
            cardToMat.Add(new Card("Triangle", i), Resources.Load<Material>("Cards/Materials/BT"+i));
            cardToMat.Add(new Card("Circle", i), Resources.Load<Material>("Cards/Materials/BC"+i));
            cardToMat.Add(new Card("Square", i), Resources.Load<Material>("Cards/Materials/BS"+i));
            cardToMat.Add(new Card("Triangle", -i), Resources.Load<Material>("Cards/Materials/RT"+i));
            cardToMat.Add(new Card("Circle", -i), Resources.Load<Material>("Cards/Materials/RC"+i));
            cardToMat.Add(new Card("Square", -i), Resources.Load<Material>("Cards/Materials/RS"+i));
        }
    }

    public static CardMatTranslate Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CardMatTranslate();
            }
            return instance;
        }
    }
}
