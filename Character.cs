using Godot;
using System;

public class Character : KinematicBody2D
{
	public int MaxSpeed = 250;
	public int Acceleration = 5;
	public int Drag = 5;
	
	private Vector2 MovementVelocity = new Vector2();
	
	//Make getters later
	public bool MoveRight = false;
	public bool MoveLeft = false;
	public bool MoveUp = false;
	public bool MoveDown = false;
	
	// BeginPlay
	public override void _Ready()
	{
	}
	
	public void GetMovementInput()
	{	
		MoveRight = Input.IsActionPressed("ui_right");
		MoveLeft = Input.IsActionPressed("ui_left");
		MoveDown = Input.IsActionPressed("ui_down");
		MoveUp = Input.IsActionPressed("ui_up");
		
		if(MoveRight && !MoveLeft)
		{
			MovementVelocity.x = Math.Min(MovementVelocity.x + Acceleration, MaxSpeed);
		}
		else
		{
			if (MovementVelocity.x > 0)
			{
				MovementVelocity.x = Math.Max(MovementVelocity.x - Drag, 0);
			}
		}
		
		if(MoveLeft && !MoveRight)
		{
			MovementVelocity.x = Math.Max(MovementVelocity.x - Acceleration, -MaxSpeed);
		}
		else
		{
			if (MovementVelocity.x < 0)
			{
				MovementVelocity.x = Math.Min(MovementVelocity.x + Drag, 0);
			}
		}
		
		if(MoveDown && !MoveUp)
		{
			MovementVelocity.y = Math.Min(MovementVelocity.y + Acceleration, MaxSpeed);
		}
		else
		{
			if (MovementVelocity.y > 0)
			{
				MovementVelocity.y = Math.Max(MovementVelocity.y - Drag, 0);
			}
		}
		
		if(MoveUp && !MoveDown)
		{
			MovementVelocity.y = Math.Max(MovementVelocity.y - Acceleration, -MaxSpeed);
		}
		else
		{
			if (MovementVelocity.y < 0)
			{
				MovementVelocity.y = Math.Min(MovementVelocity.y + Drag, 0);
			}
		}
		
		float Mag = (float)Math.Sqrt((MovementVelocity.x * MovementVelocity.x) + (MovementVelocity.y * MovementVelocity.y));
		if (Mag > MaxSpeed)
		{
			if (Mag > 0) // just incase
			{ 
				MovementVelocity = new Vector2((MovementVelocity.x / Mag) * MaxSpeed, (MovementVelocity.y / Mag) * MaxSpeed);
			}
		}
	}
	
	
	public void GetInteractionInput()
	{
		if(Input.IsActionPressed("left_mouse_click"))
		{
			GetTree().CallGroup("Inputs", "OnLeftMouseClick"); //Calls the function in text here
		}
		
		if(Input.IsActionPressed("right_mouse_click"))
		{
			GetTree().CallGroup("Inputs", "OnRightMouseClick");
		}
	}
	
  // Tick
  	public override void _Process(float delta)
  	{
		GetMovementInput();
		GetInteractionInput();
		MoveAndCollide(MovementVelocity * delta);
  	}
}
