using Godot;
using System.Collections.Generic;

public partial class Round : StateMachineNode<Round>
{
    [Export]
    public List<Participant> Participants;

    [Export]
    public int Turn;

    [Export]
    public List<Card> CardsInPlay;

    [Export]
    public List<Card> Deck;
}
