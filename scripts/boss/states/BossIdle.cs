using Godot;
using System;

public partial class BossIdle : BossState
{	
	[Export] public float idleTime = 1.5f; // Tempo que ele fica parado
    private float _timer = 0.0f;
	public override void Enter()
	{
		base.Enter();
		_timer = 0.0f;

		//garante parada de movimento
		Vector2 velocity = BossNode.Velocity;
        velocity.X = 0;
        BossNode.Velocity = velocity;

		// Inicializa o estado idle
		//BossNode.PlayAnimation("Idle");
	}

	public override void Exit()
	{
		
		
	}


    public  override void PhysicsUpdate(double delta)
    {
		BossNode.LookAtPlayer();

        _timer += (float)delta;

        if (_timer >= idleTime)
        {
            BStateMachine.ChangeState("BossWalk"); 
        }
		

    }

}