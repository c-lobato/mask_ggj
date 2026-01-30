using Godot;
using System;

public partial class BouncingCloud : Area2D
{
	[Export] public CharacterBody2D Character;
	[Export] public AnimatedSprite2D Animation;
	private float BounceSpeed = -500f;
	private void _on_body_entered(Node2D body)
	{
		if (body is CharacterBody2D character)
		{
			Animation.Play("bounce");
			var Vel = Character.Velocity;
			Vel.Y = BounceSpeed;
			character.Velocity = Vel;
		}
	}
}
