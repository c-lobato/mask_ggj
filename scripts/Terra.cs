using Godot;
using System;

public partial class Terra : CharacterBody2D
{
	[Export] private AnimatedSprite2D Animation;
	// [Export] public CpuParticles2D WalkDust;
	// [Export] public CpuParticles2D JumpDust;

	//variaveis booleanas de poderes do personagem
	private bool canDoubleJump;
	private bool canDash; 
	private bool canAttack; 
	private bool canBlock;

	//ao carregar o jogo as variaveis serão setadas como false
	public void _Ready()
	{
		canDoubleJump = false;
		canAttack = false;
		canDash = false;
		canBlock = false;
	}

	// public enum PlayerEffect
	// {
	// 	WalkEffect,
	// 	JumpEffect
	// }

	public override void _PhysicsProcess(double delta)
	{
		FlipPlayer();
	}

	public void AnimationPlayer(StringName name)
	{
		if(Animation.Animation == name)
			return;
		Animation.Play(name);
	}
	private void FlipPlayer()
	{
		if(Velocity.X != 0)
		{
			Animation.FlipH = Velocity.X < 0;
		}
	}

	// public void PlayEffect(PlayerEffect effect)
	// {
	// 	switch (effect)
	// 	{
	// 		case PlayerEffect.WalkEffect:
	// 			WalkDust.Emitting = true;
	// 			break;
	// 		case PlayerEffect.JumpEffect:
	// 			JumpDust.Emitting = true;
	// 			break;
	// 	}
	// } 

	// public void StopEffect(PlayerEffect effect)
	// {
	// 	switch (effect)
	// 	{
	// 		case PlayerEffect.WalkEffect:
	// 			WalkDust.Emitting = false;
	// 			break;
	// 		case PlayerEffect.JumpEffect:
	// 			JumpDust.Emitting = false;
	// 			break;
	// 	}
	// }
}
