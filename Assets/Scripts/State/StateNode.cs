using Godot;
public partial class StateNode<T> : Node
    where T : Node
{
    private bool _active;
    public bool Active {
        get{
            return _active;
        }
    }

    public virtual void OnEnter(StateNode<T> priorState)
    {
        _active = true;
    }

    public virtual void OnExit(StateNode<T> nextState = null)
    {
        _active = false;
    }
    public virtual void OnProcess(double delta){ }
    public virtual void OnPhysicsProcess(double delta){}
}
