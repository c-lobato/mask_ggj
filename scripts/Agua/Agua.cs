using Godot;
using System;

public partial class Agua : CharacterBody2D
{	
	[Export] private AnimatedSprite2D Animation;
	
	
	public override void _PhysicsProcess(double delta)
	{
		FlipPlayer();
	}
	public void AnimationPlayer(StringName name)
	{
		if(Animation.Animation == name)
			return;
		Animation.Play(name);
	}
	private void FlipPlayer()
	{
		if(Velocity.X != 0)
		{
			Animation.FlipH = Velocity.X < 0;
		}
	}
}
