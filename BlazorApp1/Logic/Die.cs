namespace BlazorApp1.Logic;

public class Die
{
    public int Value { get; private set; } = 1;

    public void Roll()
    {
        Value = Random.Shared.Next(1, 7);
    }
    public void SetValue(int value)
    {
        if (value >= 1 && value <= 6)
        {
            Value = value;
        }
    }
}