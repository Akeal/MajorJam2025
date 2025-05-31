using Godot;
using System;

public partial class Deal : State<Round>
{
    public override void OnEnter(State<Round> priorState)
    {
        base.OnEnter(priorState);
        PlayDealAnimation(0);
    }
    // for(int c = 0; c < Agent.startingHandSize; c++){
    //     for(int i = 0; i < Agent.Participants.Count; i++){
    //             Card nextCard = Agent.Deck.Pop();
    //             nextParticipant = 
    //         }
    //     }
    // }

    private void PlayDealAnimation(int participantIndex)
    {
        Card nextCard = Agent.Deck.Pop();
        
        // Play deal animation to participant

        // Move below into animation callback
        Agent.Participants[participantIndex].Hand.Add(nextCard);
        if(Agent.Participants[Agent.Participants.Count - 1].Hand.Count != Agent.StartingHandSize)
        {
            PlayDealAnimation(participantIndex == Agent.Participants.Count ? 0 : participantIndex + 1);
        }
    }

    public override void OnProcess(double delta)
    {
        base.OnProcess(delta);
        if(Agent.Participants[Agent.Participants.Count].Hand.Count != Agent.StartingHandSize){
            // We're waiting for all cards to be dealt
            return;
        }
        Agent.ChangeState(new Begin());
    }
}
