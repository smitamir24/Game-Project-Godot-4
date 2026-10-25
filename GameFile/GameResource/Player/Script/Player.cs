using Godot;
using System;

public partial class Player : CharacterBody3D
{
	public const float Speed = 5.0f;
	public const float JumpVelocity = 4.5f;
 	public Node3D CameraPivot; 
	public bool CursorActive = false; 

    public override void _Ready()
    {
        CameraPivot = GetNode<Node3D>("%CameraPivot");
    }


    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Cursor"))
		{
			CursorActive = !CursorActive;

			if (CursorActive == false)
			{
				Input.MouseMode = Input.MouseModeEnum.Captured;
			} 
			else
			{
				Input.MouseMode = Input.MouseModeEnum.Visible;
			}
		}
    }


	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;


		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("Jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}


		Vector2 inputDir = Input.GetVector("Left", "Right", "Up", "Down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
