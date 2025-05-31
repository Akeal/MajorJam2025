using Godot;
using System;

public partial class PlayerTakeTurn : TakeTurn<Player>
{
    private bool playComplete = false;
    public PlayerTakeTurn(Round round) : base(round){}

    public override void OnEnter(State<Participant> priorState)
    {
        base.OnEnter(priorState);
        // Enable the player to click and drag cards
    }

    public override void OnExit(State<Participant> nextState = null)
    {
        base.OnExit(nextState);
        // Disable the player ability to click and drag cards
    }

    public override void OnProcess(double delta)
    {
        base.OnProcess(delta);
        if(!playComplete)
        {
            // We're waiting for the card play animation to complete
            return;
        }

        if(Agent.Tokens.Count > 0){
            Agent.ChangeState(new PlayerWaitForTurn());
        }
        else{
            Agent.ChangeState(new PlayerLose());
        }
    }
}
