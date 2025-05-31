using Godot;
using System;
using System.Collections.Generic;

public partial class Participant : StateMachineNode<Participant>
{
    [Export]
    public List<Card> Hand;

    [Export]
    public Round Round;

}
