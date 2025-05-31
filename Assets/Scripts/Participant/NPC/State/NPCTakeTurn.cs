using Godot;
using System;

public partial class NPCTakeTurn : TakeTurn<NPC>
{
    private Card cardToPlay;
    public NPCTakeTurn(Round round) : base(round){}
    public override void OnEnter(State<Participant> priorState)
    {
        base.OnEnter(priorState);
        cardToPlay = Agent.Hand[0];
        PlayCardAnimation();
    }

    private void PlayCardAnimation()
    {

        // Once the animation completes we want to remove the card from their hand
        Agent.Hand.RemoveAt(0);
    }

    public override void OnProcess(double delta)
    {
        base.OnProcess(delta);
        if(Agent.Hand.Count > 0 || Agent.Hand[0] == cardToPlay)
        {
            // We're waiting for the card play animation to complete
            return;
        }

        if(Agent.Tokens.Count > 0){
            Agent.ChangeState(new NPCWaitForTurn());
        }
        else{
            Agent.ChangeState(new NPCLose(_round));
        }
    }
}
