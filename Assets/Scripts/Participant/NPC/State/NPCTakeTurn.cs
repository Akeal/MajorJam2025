using Godot;
using System;

public partial class NPCTakeTurn : TakeTurn<NPC>
{
    public override void OnEnter(State<Participant> priorState)
    {
        base.OnEnter(priorState);
        
    }
}
