using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class DrawCard : State<Participant>
{
    private Round _round;
    private Card _nextCard;

    public DrawCard(Round round)
    {
        this._round = round;
    }

    public override void OnEnter(State<Participant> priorState)
    {
        base.OnEnter(priorState);
        GetNextCard();
        PlayDrawAnimation(_nextCard);
    }

    public override void OnProcess(double delta)
    {
        base.OnProcess(delta);
        while(Agent.Hand.Count == 0 || Agent.Hand[0] != _nextCard)
        {
            // We're waiting for the draw animation to complete
            // This may need adjustment once we have an animation to complete
            return;
        }

        // The participant has drawn the card and can now take their turn
        _nextCard.ChangeState(new Held(Agent));
        Agent.ChangeState(Agent is Player ? new PlayerTakeTurn(_round) : new NPCTakeTurn(_round));
    }

    private void PlayDrawAnimation(Card nextCard)
    {
        // Start draw animation

        // Move this into an animation complete callback
        Agent.Hand.Add(nextCard);
    }

    private void GetNextCard(){

        // If the deck is out of cards we need to shuffle the cards in play back into the deck sans the top card
        if(_round.Deck.Count == 0){
            Card topCard = _round.CardsInPlay.Pop();

            List<Card> shufflePile = new List<Card>();

            Random rng = new Random();

            while(_round.CardsInPlay.Count > 0){
                shufflePile.Add(_round.CardsInPlay.Pop());
            }

            shufflePile.OrderBy(c => rng.Next());

            while(shufflePile.Count > 0){
                Card nextCard = shufflePile[0];
                _round.CardsInPlay.Push(nextCard);
                shufflePile.RemoveAt(0);
            }

            _round.CardsInPlay.Push(topCard);
        }

        _nextCard = _round.Deck.Pop();
    }
}
