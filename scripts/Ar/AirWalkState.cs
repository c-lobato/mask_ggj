using Godot;
using System;

public partial class AirWalkState : State
{
	[Export] public CharacterBody2D Character;
	[Export] public Ar Ar;
	protected const float WalkSpeed = 150.0f;
    
	public override void Enter()
    {
		// Terra.PlayEffect(Terra.PlayerEffect.WalkEffect);
        Ar.AnimationPlayer("airwalkstate");
    }

    public override void PhysicsUpdate(double delta)
    {
		if (!Ar.SfxWalk.Playing)
		{
			Ar.SfxWalk.Play();
		}
		if(!Character.IsOnFloor())
			StateMachine.ChangeState("airfallstate");
		
		// Terra.WalkDust.Emitting = true;
		var Vel = Character.Velocity;
	   	var Direction = Input.GetAxis("MoveLeft", "MoveRight");

	   	if(Direction == 0)
		{
			StateMachine.ChangeState("airidlestate");
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
			StateMachine.ChangeState("airjumpstate");
		}
		var dir = Input.GetAxis("MoveLeft", "MoveRight");
        if (Input.IsActionJustPressed("Dash") && dir != 0 && !Ar.Dashing && Ar.DashTimer <= 0.0f)
        {
            StateMachine.ChangeState("airdashstate");
        }
    }

    public override void Exit()
    {
        // Terra.StopEffect(Terra.PlayerEffect.WalkEffect);
    }



}
