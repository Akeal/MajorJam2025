using Godot;
using System;

public partial class Playing<T> : State<Participant> where T : Participant
{
    public override void OnEnter(State<Participant> priorState)
    {
        base.OnEnter(priorState);
        // Draw hand, or otherwise initialize the start of a round
    }

    // We don't need a generic lose state. There likely will be a large difference between an NPC and player lose state
}
