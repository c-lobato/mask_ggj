using Godot;
using System;
using System.Numerics;
using System.Runtime.InteropServices;

public partial class Submarine : RigidBody2D
{
	[Export] private AnimatedSprite2D animatedSprite;
	[Export] private float speed = 200.0f;
	[Export] public PackedScene ProjectileScene { get; set; }
	private Timer _shotTimer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animatedSprite.Play("default");
		_shotTimer = GetNode<Timer>("Timer");
		_shotTimer.Timeout += OnShotTimerTimeout;
		_shotTimer.WaitTime = GD.RandRange(1.0, 3.0);
		_shotTimer.Start();

		LinearVelocity = new Godot.Vector2(speed, speed).Rotated((float)GD.RandRange(0, Math.PI * 2));
	}

    public override void _IntegrateForces(PhysicsDirectBodyState2D state)
    {
        state.LinearVelocity = state.LinearVelocity.Normalized() * speed;

		if (state.LinearVelocity.X > 0.5f)
		{
			animatedSprite.FlipH = false;
		} 
		else if (state.LinearVelocity.X < -0.5f)
		{
			animatedSprite.FlipH = true;
		}
    }

	public void OnShotTimerTimeout()
	{
		Shoot();
        // Reinicia o timer com tempo aleatório para o próximo tiro
        _shotTimer.WaitTime = GD.RandRange(1.0, 3.0);
	}

	private void Shoot()
    {
        if (ProjectileScene == null) return;

        var projetil = (Node2D)ProjectileScene.Instantiate();
        // [Inference] Usar GlobalPosition para garantir que o tiro saia do lugar certo no mundo
        projetil.GlobalPosition = GlobalPosition;
        GetParent().AddChild(projetil);

        if (projetil is Projectile p) 
        {
            // Se o LinearVelocity.X for positivo, vai para a direita (1), senão esquerda (-1)
            p.XDirection = LinearVelocity.X > 0 ? 1 : -1;
        }
    }


	/*
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
	*/

	
}
