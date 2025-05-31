using Godot;
using System;

public partial class Draw : State<Card>
{
    private Participant _participant;
    public Draw(Participant participant){
        this._participant = participant;
    }

    public override void OnEnter(State<Card> priorState)
    {
        base.OnEnter(priorState);
        _participant.Hand.Add(Agent);
    }

    public override void OnProcess(double delta)
    {
        base.OnProcess(delta);
        // Do draw animation shit


        Agent.ChangeState(new Held(this._participant));
    }
}
