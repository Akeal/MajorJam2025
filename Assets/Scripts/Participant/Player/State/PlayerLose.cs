using Godot;
using System;

public partial class PlayerLose : Lose<Player>
{
    // whomp

    public override void OnEnter(State<Participant> priorState)
    {
        base.OnEnter(priorState);
    }
}
