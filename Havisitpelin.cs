using Godot;
using System;

public partial class Havisitpelin : Control
{
	// Called when the node enters the scene tree for the first time.b
	private TextureButton _button;
	public override void _Ready()
	{
		_button = GetNode<TextureButton>("Retry");
		_button.Pressed += OnButtonPressed;
	}

	private void OnButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://adas.tscn");
	}
}
