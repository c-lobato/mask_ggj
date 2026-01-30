using Godot;
using System;

public partial class AirDashState : State
{
	[Export] public CharacterBody2D Character;
	[Export] public Ar Ar;
    public float DashSpeed = 700.0f;       
    public float DashDistance = 200.0f;    
    public float DashStartingPosition = 0.0f;
    public float DashDirection = 0.0f;
    public float DashCooldown = 1.0f;
	public float CurrentDistance;

	public override void Enter()
    {
        var inputDir = Input.GetAxis("MoveLeft", "MoveRight");
		Ar.SfxDash.Play();
        if (inputDir != 0)
            DashDirection = Math.Sign(inputDir);
        else
            DashDirection = Ar.FacingDirection != 0 ? Ar.FacingDirection : 1;

        DashStartingPosition = Character.GlobalPosition.X;
        CurrentDistance = 0.0f;
        Ar.Dashing = true;
        
        Character.Velocity = new Vector2(DashDirection * DashSpeed, 0);
        Ar.DashTimer = DashCooldown;
    }

	public override void PhysicsUpdate(double delta)
    {
        
        Character.Velocity = new Vector2(DashDirection * DashSpeed, 0);
        Character.MoveAndSlide();

        CurrentDistance = Math.Abs(Character.GlobalPosition.X - DashStartingPosition);

        
        if (CurrentDistance >= DashDistance || Character.IsOnWall())
        {
            Ar.Dashing = false;
            StateMachine.ChangeState("airfallstate");
        }
    }

	public override void Exit()
    {
        Ar.Dashing = false;
    }

	public override void HandleInput(InputEvent @event)
    {
		if (Input.IsActionJustPressed("Jump") && (Ar.CanDoubleJump))
		{
			Ar.CanDoubleJump = false;
			StateMachine.ChangeState("airjumpstate");
		}
    }
}
