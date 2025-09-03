using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private float _speed = 600;
    private Vector2 _movementVector = Vector2.Zero;
    public const float JumpVelocity = -700.0f;
    public const int maxJumps = 2;
    private int jumpCount = 2;

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
        if (Input.IsActionJustPressed("ui_accept") && jumpCount > 0)
        {
            velocity.Y = JumpVelocity;
            velocity.X = _movementVector.X * _speed;
            jumpCount--;
        }

        if (IsOnFloor())
        {
            if (_movementVector != Vector2.Zero)
            {
                velocity.X = _movementVector.X * _speed;
            }
            else
            {
                velocity.X = Mathf.MoveToward(Velocity.X, 0, _speed);
            }
        }
        else
        {
            if (_movementVector != Vector2.Zero)
            {
                velocity.X += _movementVector.X * _speed * 0.05f;
            }
        }

        Velocity = velocity;

        if (IsOnFloor())
            jumpCount = maxJumps;
        MoveAndSlide();
    }

    private void Jump()
    {
    }
}
