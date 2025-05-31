using Godot;
using System;

// idk a better word for "is in the deck"
public partial class Undrawn : State<Card>
{
    public override void OnEnter(State<Card> priorState)
    {
        base.OnEnter(priorState);
    }
}
