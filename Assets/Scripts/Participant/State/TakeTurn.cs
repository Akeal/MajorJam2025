using System;
using System.Collections.Generic;
using System.Linq;

public partial class TakeTurn<T> : State<Participant> where T : Participant
{
    protected Round _round;

    public TakeTurn(Round round)
    {
        this._round = round;
    }


    public override void OnEnter(State<Participant> priorState)
    {
        base.OnEnter(priorState);
    }


}
