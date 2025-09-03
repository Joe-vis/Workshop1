using Godot;
using System;

public partial class Camera : Camera2D
{
	[Export] private float Speed = 100f;
	private Vector2 velocity = Vector2.Up;

	public override void _Process(double delta)
	{
		Position += velocity * Speed * (float)delta;
	}
}
