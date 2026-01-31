using Godot;
using System;

public partial class Projectile : Area2D
{
    [Export] public float Speed = 300f;
    [Export] public AnimatedSprite2D _animatedSprite2D;
    public int XDirection = 1;

    public override void _Ready()
    {
        BodyEntered += OnBodyEntered; // Conexão do sinal
    }

    private void OnBodyEntered(Node2D body)
{
    if (body.Name == "Agua" || body.IsInGroup("Player"))
    {        
        GetTree().CallDeferred(SceneTree.MethodName.ReloadCurrentScene);
    }
    
    if (body is TileMapLayer || body is StaticBody2D)
    {
        CallDeferred(MethodName.QueueFree);
    }
}

    public void SetDirection(int direction)
    {
        XDirection = direction;
        if (_animatedSprite2D == null) 
            _animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        _animatedSprite2D.FlipH = (direction < 0);
    }

    public override void _Process(double delta)
    {
        Position += new Vector2(XDirection * Speed * (float)delta, 0);
    }
}
