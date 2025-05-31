using Godot;
using System;

public partial class Turn : State<Round>
{
    private int intialParticipantCount;
    private Participant _participant;

    public Turn(Participant participant){
        this._participant = participant;
    }

    public override void OnEnter(State<Round> priorState)
    {
        base.OnEnter(priorState);
        intialParticipantCount = Agent.Participants.Count;
        //_participant.ChangeState(); Participant begins thems turn
    }

    public override void OnProcess(double delta)
    {
        base.OnProcess(delta);
        if((_participant.CurrentState is WaitForTurn<Participant>)){
            // We're now waiting for our next turn - let the next poor soul go
            if(intialParticipantCount == Agent.Participants.Count)
            {
                // We only want to increment the turn counter if the current player didn't just lose
                Agent.Turn++;
            }

            if(Agent.Turn > Agent.Participants.Count)
            {
                Agent.Turn = 0;
            }
            
            Agent.ChangeState(new Turn(Agent.Participants[Agent.Turn]));
        }
    }
}
