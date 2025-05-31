using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public partial class Round : StateMachineNode<Round>
{
    [Export]
    public int StartingHandSize = 5;
    public List<IRule> Rules;

    [Export]
    public List<Participant> Participants;

    [Export]
    public int Turn;

    [Export]
    public Stack<Card> CardsInPlay;

    [Export]
    public Stack<Card> Deck;

    [Export]
    public Stack<Token> Pot;
}
