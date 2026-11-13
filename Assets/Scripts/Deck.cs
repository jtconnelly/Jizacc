using System.Collections.Generic;
using UnityEngine;

public static class CardMaterialLoader
{
    public static Material LoadMaterial(SabaccSuit suit, int value)
    {
        string materialName;
        if (suit == SabaccSuit.Zero)
        {
            materialName = "Zero";
        }
        else
        {
            string suitCode;
            switch (suit)
            {
                case SabaccSuit.Circle:
                    suitCode = "C";
                    break;
                case SabaccSuit.Square:
                    suitCode = "S";
                    break;
                case SabaccSuit.Triangle:
                    suitCode = "T";
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException(nameof(suit), suit, "Unsupported card suit.");
            }

            materialName = $"{(value > 0 ? "B" : "R")}{suitCode}{Mathf.Abs(value)}";
        }

        Material material = Resources.Load<Material>(materialName);
        if (material == null)
        {
            throw new System.InvalidOperationException(
                $"Card material '{materialName}' was not found under Assets/Cards/Materials/Resources.");
        }

        return material;
    }

    public static Material LoadMaterial(PazaakSuit suit, int value)
    {
        string suitCode;
        switch (suit)
        {
            case PazaakSuit.Red:
                suitCode = "R";
                break;
            case PazaakSuit.Green:
                suitCode = "G";
                break;
            case PazaakSuit.Blue:
                suitCode = "B";
                break;
            case PazaakSuit.Yellow:
                suitCode = "Y";
                break;
            default:
                throw new System.ArgumentOutOfRangeException(nameof(suit), suit, "Unsupported card suit.");
        }

        string materialName = $"{(value > 0 ? "B" : "R")}{suitCode}{Mathf.Abs(value)}";

        Material material = Resources.Load<Material>(materialName);
        if (material == null)
        {
            throw new System.InvalidOperationException(
                $"Card material '{materialName}' was not found under Assets/Cards/Materials/Resources.");
        }

        return material;
    }
}
public static class ListExtensions
{
    public static List<T> Shuffle<T>(this List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    }

    public static Stack<T> ToStack<T>(this List<T> list)
    {
        var stack = new Stack<T>();
        foreach (var item in list)
        {
            stack.Push(item);
        }
        return stack;
    }
}

public class SabaccDeck : IDeck
{

    private void InitializeDeck()
    {
        cards.Clear();
        foreach (SabaccSuit suit in System.Enum.GetValues(typeof(SabaccSuit)))
        {
            if (suit == SabaccSuit.Zero) continue;
            for (int value = 1; value <= 10; value++)
            {
                cards.Add(new SabaccCard { suit = suit, value = value, material = CardMaterialLoader.LoadMaterial(suit, value) });
                cards.Add(new SabaccCard { suit = suit, value = -value, material = CardMaterialLoader.LoadMaterial(suit, -value) });
            }
        }
        cards.Add(new SabaccCard { suit = SabaccSuit.Zero, value = 0, material = CardMaterialLoader.LoadMaterial(SabaccSuit.Zero, 0) });
        cards.Add(new SabaccCard { suit = SabaccSuit.Zero, value = 0, material = CardMaterialLoader.LoadMaterial(SabaccSuit.Zero, 0) });
    }


    public SabaccDeck()
    {
        cards = new List<ICard>();
        deck = new Stack<ICard>();
        InitializeDeck();
        Shuffle();
    }
}

public class PazaakDeck : IDeck
{
    public PazaakDeck()
    {
        cards = new List<ICard>();
        deck = new Stack<ICard>();
        InitializeDeck();
        Shuffle();
    }

    private void InitializeDeck()
    {
        cards.Clear();
        foreach (PazaakSuit suit in System.Enum.GetValues(typeof(PazaakSuit)))
        {
            for (int value = 1; value <= 10; value++)
            {
                cards.Add(new PazaakCard { suit = suit, value = value, material = CardMaterialLoader.LoadMaterial(suit, value) });
                cards.Add(new PazaakCard { suit = suit, value = -value, material = CardMaterialLoader.LoadMaterial(suit, -value) });
            }
        }
    }
}