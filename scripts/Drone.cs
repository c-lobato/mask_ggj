using Godot;
using System;

public partial class Drone : Area2D
{
	[Export] private Terra Terra;

	private void _on_body_entered()
	{
		// Terra.TakeDamage();
		// QueueFree(); Talvez se ele se explodir
	}
}
