using Godot;

public partial class PlayerCutscene : Control
{
    public string NextLevelPath = "res://scenes/level_air.tscn";
    private VideoStreamPlayer _video;

    public override void _Ready()
    {
        _video = GetNode<VideoStreamPlayer>("VideoStreamPlayer");
        _video.Play();
    }

    private void OnVideoFinished()
    {
		GetTree().ChangeSceneToFile(NextLevelPath);
    }
}