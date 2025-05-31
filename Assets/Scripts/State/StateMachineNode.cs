using Godot;
using System.Collections.Generic;

public partial class StateMachineNode<T> : Node
    where T : Node
{
    public T Agent
    {
        get
        {
            return this as T;
        }
    }

    protected Stack<State<T>> stateStack = new Stack<State<T>>();
    public virtual State<T> CurrentState
    {
        get
        {
            return stateStack.Count > 0 ? stateStack.Peek() : new State<T>(Agent);
        }
    }

    public void PushState(State<T> nextState)
    {
        State<T> priorState = CurrentState;
        stateStack.Push(nextState);
        nextState.OnEnter(priorState);
    }

    public State<T> PopState()
    {
        if(stateStack.TryPop(out State<T> priorState))
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
