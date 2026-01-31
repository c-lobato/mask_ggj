using Godot;
using System;

public partial class Drone : Area2D
{
	[Export] private Ar Ar;
	[Export] private Timer Timer;

	private void _on_body_entered(Node2D body)
	{
		if (body is CharacterBody2D player)
        {
			Timer.Start();
			Ar.Hitbox.QueueFree();
        }
	}
	public void _on_timer_timeout()
	{
		GetTree().ReloadCurrentScene();
	}
}
