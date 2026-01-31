using Godot;
using System;

public partial class Boss : CharacterBody2D
{
    [Export] public Terra playerRef; 
    [Export] public AnimatedSprite2D animation;
    [Export] public BossStateMachine BStateMachine;

    [Export] public float BWalkSpeed = 70.0f;
    public float gravity = 980.0f;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        if (!IsOnFloor())
            velocity.Y += gravity * (float)delta;

        Velocity = velocity;
        MoveAndSlide();
    }

    public void LookAtPlayer()
    {
        if (playerRef == null) return;
        float direction = playerRef.GlobalPosition.X - GlobalPosition.X;
        //if (direction != 0) animation.FlipH = direction < 0;
    }

    public void PlayAnimation(string animName)
    {
       // if (animation.Animation != animName) animation.Play(animName);
    }
}