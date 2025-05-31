public partial class Held : State<Card>
{
    private Participant _participant;

    public Held(Participant participant)
    {
        this._participant = participant;
    }

    public override void OnEnter(State<Card> priorState)
    {
        base.OnEnter(priorState);
    }

    public void Play()
    {
        Agent.ChangeState(new Play(_participant));
    }
}
