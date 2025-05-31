using Godot;
using System;

public partial class Play : State<Card>
{
    private Participant _participant;

    public Play(Participant participant){
        this._participant = participant;
    }

    public override void OnEnter(State<Card> priorState)
    {
        base.OnEnter(priorState);
        this._participant.Hand.Remove(Agent);
        // Do play animation shit

        // Do rule evaluation shit

        Agent.ChangeState(new Played());
    }
}
