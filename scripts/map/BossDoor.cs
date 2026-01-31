using Godot;
using System;

public partial class PortaBoss : Node
{
    [Export] public StaticBody2D corpoFisico;
    [Export] public CollisionShape2D colisaoPorta;
    [Export] public Sprite2D spritePorta;

    public override void _Ready()
    {
        // começa com a porta aberta/atravessável
        colisaoPorta.SetDeferred("disabled", true);
        spritePorta.Visible = false;
    }

    private void _on_gatilho_entrada_body_entered(Node body)
    {
        // verifica se quem passou foi o Player (Terra)
        if (body is Terra)
        {
            FecharPorta();
        }
    }

    private void FecharPorta()
    {
        // ativa a colisão e mostra o visual
        colisaoPorta.SetDeferred("disabled", false);
        spritePorta.Visible = true;

        GD.Print("A porta se fechou! O combate começou.");
        
        // Opcional: Desativa o gatilho para não rodar o código de novo
        GetNode<Area2D>("GatilhoEntrada").QueueFree();
    }
}