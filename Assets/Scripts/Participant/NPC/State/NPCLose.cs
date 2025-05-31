using Godot;
using System;

public partial class NPCLose : Lose<NPC>
{
    private Round _round;
    public NPCLose(Round round){
        this._round = round;
    }

    public override void OnEnter(State<Participant> priorState)
    {
        base.OnEnter(priorState);
        // Please find your way to the exit
    }
}
