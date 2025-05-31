using Godot;
using System.Collections.Generic;

public partial class StateMachineNode<T> : Node
    where T : Node
{
    [Export]
    private T _actor;
    public T Actor 
    {
        get
        {
            return _actor;
        }
    }

    private Stack<State<T>> _stateStack;
    public State<T> CurrentState
    {
        get{
            return _stateStack.Peek();
        }
    }

    public void PushState(State<T> nextState)
    {
        State<T> priorState = CurrentState;
        _stateStack.Push(nextState);
        nextState.OnEnter(priorState);
    }

    public State<T> PopState()
    {
        State<T> priorState = null;
        if(_stateStack.TryPop(out priorState))
        {
            priorState.OnExit(CurrentState);
        }
        return priorState;
    }

    public State<T> ChangeState(State<T> nextState)
    {
        State<T> priorState = PopState();
        PushState(nextState);
        return priorState;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        CurrentState?.OnProcess(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        CurrentState?.OnPhysicsProcess(delta);
    }
}
