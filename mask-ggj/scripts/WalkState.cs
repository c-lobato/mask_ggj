using Godot;
using System;

public partial class WalkState : State
{
	[Export] public CharacterBody2D Character;
	[Export] public Terra Terra;
	protected const float WalkSpeed = 100.0f;
    
	public override void Enter()
    {
		// Terra.PlayEffect(Terra.PlayerEffect.WalkEffect);
        Terra.AnimationPlayer("walkstate");
    }

    public override void PhysicsUpdate(double delta)
    {
		if(!Character.IsOnFloor())
			StateMachine.ChangeState("fallstate");
		
		// Terra.WalkDust.Emitting = true;
		var Vel = Character.Velocity;
	   	var Direction = Input.GetAxis("MoveLeft", "MoveRight");

	   	if(Direction == 0)
		{
			StateMachine.ChangeState("idlestate");
			return;
		}

		Vel.X = Direction * WalkSpeed;
		Character.Velocity = Vel;
		Character.MoveAndSlide();

    }

    public override void HandleInput(InputEvent @event)
    {
        if (Input.IsActionJustPressed("Jump"))
		{
			StateMachine.ChangeState("jumpstate");
		}
    }

    public override void Exit()
    {
        // Terra.StopEffect(Terra.PlayerEffect.WalkEffect);
    }



}
