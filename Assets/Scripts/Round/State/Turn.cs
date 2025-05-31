using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

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
        
        _participant.ChangeState(_participant is Player ? new PlayerTakeTurn(Agent) : new NPCTakeTurn(Agent));
    }

    public override void OnProcess(double delta)
    {
        base.OnProcess(delta);

        if(!(_participant.CurrentState is WaitForTurn<Participant>))
        {
            return;
        }
        else if(_participant is Player && _participant.CurrentState is PlayerLose){
            // No next turn. s'all over man
            Agent.ChangeState(new PlayerLoseRound());
        }
        else if(_participant is NPC && Agent.Participants[0] is Player){
            // No next turn. s'all over man... in a good way
            Agent.ChangeState(new PlayerWinRound());
        }

        // The current participant is now waiting for our next turn - let the next poor soul go
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
