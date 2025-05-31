using Godot;

public partial class Card : StateMachineNode<Card>
{
    public enum CardSuit
    {
        A,
        B,
        C,
        D,
    }

    public enum CardValue
    {
        joker,
        ace,
        one,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine,
        jack,
        king,
        queen
    }

    [Export]
    public CardSuit Suit;

    [Export]
    public CardValue Value;


}
