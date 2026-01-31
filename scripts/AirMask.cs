using Godot;
using System;

public partial class AirMask : Area2D
{
	private void _on_body_entered(Node2D body)
	{
		if (body is CharacterBody2D player)
        {
			GetTree().ChangeSceneToFile("res://scenes/waterLevel.tscn");
        }
	}
}
