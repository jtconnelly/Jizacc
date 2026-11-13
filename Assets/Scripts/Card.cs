using UnityEngine;

public enum SabaccSuit
{
    Triangle,
    Circle,
    Square,
    Zero
}
public interface ICard
{
    int value { get; set; }
    Material material { get; set; }
}
public class SabaccCard : ICard
{
    public int value { get; set; }
    public Material material { get; set; }
    public SabaccSuit suit { get; set; }
}

public enum PazaakSuit
{
    Red,
    Green,
    Blue,
    Yellow
}

public class PazaakCard : ICard
{
    public int value { get; set; }
    public Material material { get; set; }
    public PazaakSuit suit { get; set; }
}