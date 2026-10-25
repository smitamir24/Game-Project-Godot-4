using Godot;
using System;

public partial class MainMenu : Control
{
	private void _on_play_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://GameFile/Game/Scene/Game.tscn");
	}

	private void _on_exit_button_pressed()
	{
		GetTree().Quit();
	}
}
