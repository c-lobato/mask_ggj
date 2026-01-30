using Godot;
using System;
using System.Numerics;

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
		var Vel = Character.Velocity;
		Vel.Y = 0;
		Vel.X = 0;
		if (!Character.IsOnFloor())
		{
			StateMachine.ChangeState("fallstate");
		}
		Character.Velocity = Vel;
		Character.MoveAndSlide();
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

