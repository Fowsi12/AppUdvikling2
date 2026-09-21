namespace BlazorApp1.Logic;

public class DieCup
{
    public List<Die> Dice { get; } = new();

    public DieCup(int numberOfDice = 2)
    {
        SetNumberOfDice(numberOfDice);
    }

    public void SetNumberOfDice(int numberOfDice)
    {
        Dice.Clear();

        for (int i = 0; i < numberOfDice; i++)
        {
            Dice.Add(new Die());
        }
    }

    public void Roll()
    {
        foreach (Die die in Dice)
        {
            die.Roll();
        }
    }
}