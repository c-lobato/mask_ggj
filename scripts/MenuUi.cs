using Godot;
using System;

public partial class MenuUi : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void onStartPressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/level_air.tscn");
	}

	public void onExitPressed()
	{
		GetTree().Quit();
	}
}
