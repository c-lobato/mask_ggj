using Godot;
using System;

public abstract partial class State : Node
{
	public StateMachine StateMachine;
	public virtual void Enter()
	{
		
	}

	public virtual void Exit()
	{
		
	}

	public virtual void Update(double delta)
	{
		
	}

    public virtual void PhysicsUpdate(double delta)
    {
        
    }

	public virtual void HandleInput(InputEvent @event)
	{

	}

}