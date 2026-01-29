using Godot;
using System;

public partial class JumpState : State
{
	[Export] public CharacterBody2D Character;
	[Export] public Terra Terra;
	protected const float WalkSpeed = 80.0f;
	protected const float JumpSpeed = -250.0f;
	protected const float Gravity = 800.0f;
    public override void Enter()
    {
		// Terra.PlayEffect(Terra.PlayerEffect.JumpEffect);
		// Terra.AnimationPlayer("jumpstate");
		var Vel = Character.Velocity;
		Vel.Y = JumpSpeed;
		Character.Velocity = Vel;
    }

    public override void PhysicsUpdate(double delta)
    {
		var Vel = Character.Velocity;

		Vel.Y += Gravity * (float)delta;

		if (Vel.Y > 0)
			StateMachine.ChangeState("fallstate");

		var Direction = Input.GetAxis("MoveLeft", "MoveRight");
		Vel.X = Direction * WalkSpeed;
		Character.Velocity = Vel;

		Character.MoveAndSlide();

		if (Character.IsOnFloor())
		{
			if (Direction != 0)
				StateMachine.ChangeState("walkstate");
			else
				StateMachine.ChangeState("idlestate");
		}
    }

}
