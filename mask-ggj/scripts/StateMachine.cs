using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node
{
	[Export] public State InitialState;
	public State CurrentState;
	public Dictionary<string, State> States = new();
	
	public override void _Ready()
	{
		foreach (Node child in GetChildren())
		{
			if (child is State st)
			{
				States[st.Name.ToString().ToLower()] = st;
				st.StateMachine = this;
			}
		}

		if(InitialState != null)
		{
			ChangeState(InitialState.Name.ToString().ToLower());
		}


	}
	public override void _Process(double delta)
	{
		if (CurrentState != null)
		{
			CurrentState.Update(delta);
		}
	
	}
    public override void _PhysicsProcess(double delta)
	{
		if (CurrentState != null)
		{
			CurrentState.PhysicsUpdate(delta);
		}
	}
	public override void _Input(InputEvent @event)
	{
		if (CurrentState != null)
		{
			CurrentState.HandleInput(@event);
		}
	}
	public void ChangeState(string NewStateName)
	{
		if(CurrentState != null)
		{
			CurrentState.Exit();
		}

		var key = NewStateName.ToLower();

		if (States.TryGetValue(key, out var newState))
		{
    		CurrentState = newState;
		}
		else
		{
    		GD.PushWarning($"State '{key}' não registrado.");
		}


		if(CurrentState != null)
		{
			CurrentState.Enter();
		}		
	}

}

