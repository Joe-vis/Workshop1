using Godot;
using System;

public partial class Camera : Camera2D
{
	[Export] private float Speed = 100f;
	private Vector2 velocity = Vector2.Up;
	private Area2D _deathBox;

	public override void _Ready()
	{
		_deathBox = GetNode<Area2D>("Deathbox");
		_deathBox.BodyEntered += OnBodyEntered;
	}

	public override void _Process(double delta)
	{
		Position += velocity * Speed * (float)delta;
	}

	private void OnBodyEntered(Node body)
	{
		if (body is Player player)
		{
			GD.Print("👽👽👽");
			player.QueueFree();
			Speed = 0f;
		}
	}
}
