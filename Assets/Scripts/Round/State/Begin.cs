using Godot;
using System;

public partial class Begin : State<Round>
{
    public override void OnEnter(State<Round> priorState)
    {
        base.OnEnter(priorState);
        PlayBeginAnimation();
    }

    private void PlayBeginAnimation()
    {
        // Move this into an animation complete callback
        Agent.CardsInPlay.Push(Agent.Deck.Pop());
    }

    public override void OnProcess(double delta)
    {
        base.OnProcess(delta);
        if(Agent.CardsInPlay.Count == 0)
        {
            return;
        }
        Agent.ChangeState(new Turn(Agent.Participants[Agent.Turn]));
    }
}
