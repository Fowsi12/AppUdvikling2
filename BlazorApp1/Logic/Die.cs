namespace BlazorApp1.Logic;

public class Die
{
    public int Value { get; private set; } = 1;

    public void Roll()
    {
        Value = Random.Shared.Next(1, 7);
    }
}