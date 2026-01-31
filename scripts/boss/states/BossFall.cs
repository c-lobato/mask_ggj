using Godot;

public partial class BossFall : BossState
{
    public override void Enter()
    {
        base.Enter();
        // BossNode.PlayAnimation("jump_down");
    }

    public override void PhysicsUpdate(double delta)
    {
        // Agora sim: se tocar o chão vindo de uma queda, ele volta pro Idle
        if (BossNode.IsOnFloor())
        {
			GD.Print("Boss: Pousou!");
            BStateMachine.ChangeState("BossIdle");
        }
    }
}