using Godot;

public partial interface IRule
{
    public enum Outcome {
        positive,
        neutral,
        negative
    }

    public Outcome Perform();
}
