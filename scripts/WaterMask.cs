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
        // Verifica se o Player (Agua) entrou no trigger
        if (body.Name == "Agua" || body.IsInGroup("Player"))
        {
            if (!string.IsNullOrEmpty(MenuScenePath))
            {
                // Uso do CallDeferred para evitar o erro de física que vimos antes
                GetTree().CallDeferred(SceneTree.MethodName.ChangeSceneToFile, MenuScenePath);
            }
            else
            {
                GD.PrintErr("Caminho da cena do Menu não definido no WaterMask!");
            }
        }
    }
}