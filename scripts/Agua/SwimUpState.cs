using Godot;
using System;

public partial class SwimUpState : State
{
	[Export] public CharacterBody2D Character;
	[Export] public Agua Agua;
	protected const float SwimSpeed = 100.0f;
	protected const float SwimUpSpeed = -270.0f;
	protected const float Gravity = 500.0f;
    public override void Enter()
    {
		// Terra.PlayEffect(Terra.PlayerEffect.JumpEffect);
		Agua.AnimationPlayer("swimupstate");
		var Vel = Character.Velocity;
		Vel.Y = SwimUpSpeed;
		Character.Velocity = Vel;
    }

	public override void PhysicsUpdate(double delta)
    {
		var Vel = Character.Velocity;

		Vel.Y += Gravity * (float)delta;

		if (Vel.Y > 0)
			StateMachine.ChangeState("swimdownstate");

		var Direction = Input.GetAxis("MoveLeft", "MoveRight");
		Vel.X = Direction * SwimSpeed;
		Character.Velocity = Vel;

		Character.MoveAndSlide();
    }

	public override void HandleInput(InputEvent @event)
    {
		if (Input.IsActionJustPressed("Jump"))
		{
			StateMachine.ChangeState("swimupstate");
		}
    }
}
