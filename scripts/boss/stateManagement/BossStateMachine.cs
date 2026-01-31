using Godot;
using System;
using System.Collections.Generic;

public partial class BossStateMachine : Node2D
{
    [Export] public BossState InitialState;
    [Export] public Label StateLabel;

    private BossState _currentState;
    private Dictionary<string, BossState> _states = new Dictionary<string, BossState>();

    public override void _Ready()
    {
        // Usamos um timer curto para garantir que o Boss e o Player já nasceram
        CallDeferred(MethodName.InitializeStateMachine);
	
    }

    private void InitializeStateMachine()
    {
        foreach (Node child in GetChildren())
        {
            if (child is BossState state)
            {
                _states[child.Name.ToString().ToLower()] = state;
                state.BStateMachine = this;
            }
        }

        if (InitialState != null)
        {
            _currentState = InitialState;
            _currentState.Enter();
        }

		if (StateLabel != null) StateLabel.Text = "Estado: " + _currentState?.Name;
    }

	public override void _PhysicsProcess(double delta)
	{
		// Sem isso, o estado atual fica "congelado" e nunca troca a Label
		_currentState?.PhysicsUpdate(delta);
		if (StateLabel != null) StateLabel.Text =_currentState?.Name;
	}

    public void ChangeState(string newStateName)
    {
        string key = newStateName.ToLower();
        if (!_states.ContainsKey(key))
		{
			
			GD.Print("estado não encontrado: " + newStateName);
		}
	
        _currentState?.Exit();
        _currentState = _states[key];
        _currentState.Enter();

    }
}