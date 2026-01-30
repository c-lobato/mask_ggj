using Godot;
using System;
using System.Formats.Asn1;

public partial class WindMask : IMask	 
{

	public void SetName(string newName)
	{
		base.SetName(newName);
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		name = "Wind Mask";
	}

	public void changePlayer(Terra player)
	{
		player.canDoubleJump = true;
		player.canDash = true;
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
