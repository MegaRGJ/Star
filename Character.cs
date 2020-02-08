using Godot;
using System;

public class Character : KinematicBody2D
{
	public int Speed = 500;

	private Vector2 MovementVelocity = new Vector2();
	
	// BeginPlay
	public override void _Ready()
	{
	}
	
	
	public void GetInput()
	{
		MovementVelocity = new Vector2();
		
		if(Input.IsActionPressed("ui_right"))
		{
			MovementVelocity.x += Speed;
		}
		
		if(Input.IsActionPressed("ui_left"))
		{
			MovementVelocity.x -= Speed;
		}
		
		if(Input.IsActionPressed("ui_down"))
		{
			MovementVelocity.y += Speed;
		}
		
		if(Input.IsActionPressed("ui_up"))
		{
			MovementVelocity.y -= Speed;
		}
	}
	
  // Tick
  	public override void _Process(float delta)
  	{
		GetInput();
		MoveAndCollide(MovementVelocity * delta);
  	}
}
