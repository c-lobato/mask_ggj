using Godot;
using System;

public partial class BossWalk : BossState
{

	[Export]public float BWalkTime = 2f;
	private float _timer = 0.0f;
	public override void Enter()
	{
		base.Enter();
		_timer = 0.0f;

		//logica da animação do boss AQUI!!!!!!!!

	}

	public override void Exit()
	{
		
	}

    public  override void PhysicsUpdate(double delta)
    {	

		if (Player == null) GD.Print("player nulo");


		//verificação
		if (BossNode == null || Player==null) return;

		//calcula a direção do Boss ao player
		float direction = Player.GlobalPosition.X - BossNode.GlobalPosition.X;

		//setup do movimento (1 para diretia , -1 pra esquerda)
		float moveDirection = direction < 0 ? -1 : 1;
		
		//velocidade (horizontal e usa a direção com a velocidade do boss)
		Vector2 velocity = BossNode.Velocity;
		velocity.X = moveDirection * BossNode.BWalkSpeed;
		BossNode.Velocity = velocity;

		BossNode.LookAtPlayer();

		//timer pra voltar ao idle (INSERIR RANDOMIZAÇÃO DEPOIS)
		_timer += (float)delta;
        if (_timer >= BWalkTime)
        {
            BStateMachine.ChangeState("BossJump");
        }

    }


}