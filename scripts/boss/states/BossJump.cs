using Godot;
using System;

public partial class BossJump : BossState
{
    [Export] public float BJumpForce = -600.0f;
    [Export] public float BHorizontalBoost = 100.0f;
    [Export] public PackedScene DustEffect; // Arraste seu efeito de poeira aqui

    private bool _hasLeftGround = false;

    public override void Enter()
    {
        base.Enter();
        _hasLeftGround = false;

        if (BossNode == null) return;

        Vector2 velocity = BossNode.Velocity;
        velocity.Y = BJumpForce;

        // Impulso na direção do player
        float direction = (Player.GlobalPosition.X > BossNode.GlobalPosition.X) ? 1 : -1;
        velocity.X = direction * BHorizontalBoost;

        BossNode.Velocity = velocity;
        // BossNode.PlayAnimation("jump_loop"); 
    }

    public override void PhysicsUpdate(double delta)
    {
        if (BossNode == null) return;

        // 1. Verifica se ele já saiu do chão (para não colidir no frame 1)
        if (!BossNode.IsOnFloor())
        {
            _hasLeftGround = true;
        }

        // 2. Se ele já saiu e agora tocou o chão de novo:
        if (_hasLeftGround && BossNode.IsOnFloor())
        {
            //SpawnDust();
            BStateMachine.ChangeState("BossIdle");
        }
    }
}