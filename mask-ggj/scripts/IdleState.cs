using Godot;
using System;

public partial class IdleState : State
{
	[Export] public CharacterBody2D Character;
	[Export] public Terra Terra;
	public override void Enter()
	{
		Terra.AnimationPlayer("idlestate");
	}

    public override void PhysicsUpdate(double delta)
    {
		if (!Character.IsOnFloor())
		{
			StateMachine.ChangeState("fallstate");
		}
    }


    public override void HandleInput(InputEvent @event)
    {
        if(Input.IsActionPressed("MoveLeft") || Input.IsActionPressed("MoveRight"))
		{
			StateMachine.ChangeState("walkstate");
		}

		else if (Input.IsActionJustPressed("Jump"))
		{
			StateMachine.ChangeState("jumpstate");
		}
    }

}

