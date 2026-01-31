using Godot;
using System;

public abstract partial class BossState : Node
{
    public BossStateMachine BStateMachine; // Referência para a máquina
    [Export] public Boss BossNode;       // Referência para o corpo do Boss

    public Terra Player => BossNode?.playerRef; // Atalho para o Player

    public override void _Ready()
    {
        SetPhysicsProcess(false); // Começa desligado
    }

    public virtual void Enter() => SetPhysicsProcess(true);
    public virtual void Exit() => SetPhysicsProcess(false);
    public virtual void PhysicsUpdate(double delta) { }
}