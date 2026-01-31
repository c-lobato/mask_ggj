using Godot;
using System;

public partial class BossDoor : Node2D
{
	[Export] public StaticBody2D corpoFisico;
	[Export] public CollisionShape2D colisaoPorta;
	[Export] public Sprite2D spritePorta;
	
	// Onde a porta vai parar (pegaremos o valor automaticamente no Ready)
	private float _yFinal; 
	private bool _foiAtivada = false;

	public override void _Ready()
	{
		if (spritePorta != null)
		{
			_yFinal = spritePorta.Position.Y;
			// Opcional: Se quiser que ela comece invisível, mas o ideal 
			// é só deixar ela escondida acima da tela/parede.
			spritePorta.Visible = true; 
		}

		if (colisaoPorta != null)
		{
			colisaoPorta.SetDeferred("disabled", true);
		}
	}

	// Certifique-se de que este sinal está conectado na aba Node do Gatilho!
	private void _on_gatilho_entrada_body_entered(Node body)
	{
		// Se o seu script do player se chamar "Terra", mantenha assim
		if (body is CharacterBody2D && !_foiAtivada) 
		{
			_foiAtivada = true;
			FecharPorta();
		}
	}

	private void FecharPorta()
	{
		GD.Print("Ativando porta!");

		colisaoPorta.SetDeferred("disabled", false);

		Tween tween = GetTree().CreateTween();
		
		tween.TweenProperty(spritePorta, "position:y", _yFinal, 0.3f)
			 .SetTrans(Tween.TransitionType.Bounce)
			 .SetEase(Tween.EaseType.Out);
	}
}
