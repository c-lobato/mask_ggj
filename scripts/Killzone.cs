using Godot;
using System;

public partial class Killzone : Area2D
{
	[Export] private Ar Ar;
	[Export] private Timer Timer;
	public void _on_body_entered(Node2D body)
    {
        if (body is CharacterBody2D player)
        {
           Timer.Start();
        }
    }

	public void _on_timer_timeout()
	{
		GetTree().ReloadCurrentScene();
	}
}
