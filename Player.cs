using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private float _speed = 600;
    private Vector2 _movementVector = Vector2.Zero;
    public const float JumpVelocity = -600.0f;


    public override void _Process(double delta)
    {
        base._Process(delta);
        _movementVector = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
    }
    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Add the gravity.
        if (!IsOnFloor())
        {
            velocity += GetGravity() * 2 * (float)delta;
        }

        // Handle Jump.
        if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
        }

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        // if (IsOnFloor())

        if (_movementVector != Vector2.Zero)
        {
            velocity.X = _movementVector.X * _speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, _speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }

    private void Jump()
    {
    }
}
