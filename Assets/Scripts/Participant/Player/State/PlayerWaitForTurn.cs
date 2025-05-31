using Godot;
using System;

public partial class PlayerWaitForTurn : WaitForTurn<Player>
{
    public override void OnEnter(State<Participant> priorState)
    {
        base.OnEnter(priorState);
        // Disable user actions
    }

    public override void OnExit(State<Participant> nextState = null)
    {
        base.OnExit(nextState);
        // Enable user actions
    }
}
