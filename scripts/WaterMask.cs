using Godot;
using System;

public partial class WaterMask : Area2D
{
    public string MenuScenePath;

    public override void _Ready()
    {
        // Conecta o sinal de colisão
        BodyEntered += OnBodyEntered;
		MenuScenePath = "res://scenes/menuUi.tscn";
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body.Name == "Agua" || body.IsInGroup("Player"))
        {
            if (!string.IsNullOrEmpty(MenuScenePath))
            {
                GetTree().CallDeferred(SceneTree.MethodName.ChangeSceneToFile, MenuScenePath);
            }
            else
            {
                GD.PrintErr("Caminho da cena do Menu não definido no WaterMask!");
            }
        }
    }
}