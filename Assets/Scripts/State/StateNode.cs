using Godot;
public partial class State<T> where T : Node
{
    private T _agent;
    protected T Agent {
        get{
            return _agent;
        }
    }

    public virtual void OnEnter(State<T> priorState)
    {
        this._agent = priorState.Agent;
    }

    public virtual void OnExit(State<T> nextState = null){ }
    public virtual void OnProcess(double delta){ }
    public virtual void OnPhysicsProcess(double delta){}
}
