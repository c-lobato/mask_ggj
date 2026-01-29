using Godot;
using System;

public partial class FallState : State
{
	[Export] public CharacterBody2D Character;
	[Export] public Terra Terra;
	protected const float WalkSpeed = 150.0f;
	protected const float Gravity = 800.0f;

    public override void Enter()
    {
        Terra.AnimationPlayer("fallstate");
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
				StateMachine.ChangeState("walkstate");
			else
				StateMachine.ChangeState("idlestate");
		}
    }
}
