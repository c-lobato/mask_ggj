using Godot;
using System;

public partial class SwimDownState : State
{
	[Export] public CharacterBody2D Character;
	[Export] public Agua Agua;
	protected const float SwimSpeed = 100.0f;
	protected const float Gravity = 100.0f;

	public override void Enter()
    {
        Agua.AnimationPlayer("swimdownstate");
    }
	public override void PhysicsUpdate(double delta)
    {
		var Vel = Character.Velocity;

		Vel.Y += Gravity * (float)delta;
		

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
