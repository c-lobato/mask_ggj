using Godot;
using System;
using System.Numerics;

public partial class AirIdleState : State
{
	[Export] public CharacterBody2D Character;
	[Export] public Ar Ar;
	public override void Enter()
	{
		Ar.AnimationPlayer("airidlestate");
	}

    public override void PhysicsUpdate(double delta)
    {
		var Vel = Character.Velocity;
		Vel.Y = 0;
		Vel.X = 0;
		if (!Character.IsOnFloor())
		{
			StateMachine.ChangeState("airfallstate");
		}
		Character.Velocity = Vel;
		Character.MoveAndSlide();
    }


    public override void HandleInput(InputEvent @event)
    {
        if(Input.IsActionPressed("MoveLeft") || Input.IsActionPressed("MoveRight"))
		{
			StateMachine.ChangeState("airwalkstate");
		}

		else if (Input.IsActionJustPressed("Jump"))
		{
			StateMachine.ChangeState("airjumpstate");
		}

		if (Input.IsActionJustPressed("Dash") && !Ar.Dashing && Ar.DashTimer <= 0.0f)
        {
            StateMachine.ChangeState("airdashstate");
        }
    }

}
