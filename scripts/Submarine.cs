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
	[Export]
	public PackedScene ProjectileScene { get; set; }
	private Timer _shotTimer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animatedSprite.Play("default");
		_shotTimer = GetNode<Timer>("Timer");
		_shotTimer.Timeout += OnShotTimerTimeout;

		_shotTimer.WaitTime = GD.RandRange(1.0, 3.0);
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

	public void OnShotTimerTimeout()
	{
		Shoot();
	}

	private void Shoot()
	{
		if (ProjectileScene == null) return;

		var projetil = (Node2D)ProjectileScene.Instantiate();
		projetil.GlobalPosition = GlobalPosition;
		GetParent().AddChild(projetil);
		GD.Print("Disparei");

		// Implementar a direção do projetil
		if (projetil is Projectile p) 
        {
            // Se o sprite está invertido, a direção é para a esquerda (-1), senão direita (1)
            p.XDirection = animatedSprite.FlipH ? -1 : 1;
        }
	}
}
