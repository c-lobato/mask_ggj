using Godot;
using System;

public partial class AirFallState : State
{
	[Export] public CharacterBody2D Character;
	[Export] public Ar Ar;
	protected const float WalkSpeed = 150.0f;
	protected const float Gravity = 800.0f;

    public override void Enter()
    {
        Ar.AnimationPlayer("airfallstate");
    }


    public override void PhysicsUpdate(double delta)
    {
		var Vel = Character.Velocity;

		Vel.Y += Gravity * (float)delta;

		var Direction = Input.GetAxis("MoveLeft", "MoveRight");
		Vel.X = Direction * WalkSpeed;
		Character.Velocity = Vel;

		Character.MoveAndSlide();

		if (Character.IsOnFloor())
		{
			
			// Terra.StopEffect(Terra.PlayerEffect.WalkEffect);
			if (Direction != 0)
				StateMachine.ChangeState("airwalkstate");
			else
				StateMachine.ChangeState("airidlestate");
		}
    }

	public override void HandleInput(InputEvent @event)
    {
		if (Input.IsActionJustPressed("Jump") && (Ar.CanDoubleJump))
		{
			Ar.CanDoubleJump = false;
			StateMachine.ChangeState("airjumpstate");
		}

		var dir = Input.GetAxis("MoveLeft", "MoveRight");
        if (Input.IsActionJustPressed("Dash") && !Ar.Dashing && Ar.DashTimer <= 0.0f)
        {
            StateMachine.ChangeState("airdashstate");
        }
    }
}
