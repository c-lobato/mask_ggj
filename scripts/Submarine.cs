using Godot;
using System;
using System.Numerics;

public partial class Submarine : RigidBody2D
{
	[Export]
	private AnimatedSprite2D animatedSprite;
	[Export]
	private int speed = 1;
	[Export]
	private float walkLimit;
	private int walkedDistance;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animatedSprite.Play("default");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (walkedDistance <= walkLimit)
		{
			Position += new Vector2I(speed, 0);
			walkedDistance += Math.Abs(speed);
		}
		else
		{
			walkedDistance = 0;
			animatedSprite.FlipH = !animatedSprite.FlipH;
			speed *= -1;
		}
		
	}
}
