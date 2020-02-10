using Godot;
using System;

public class SunPotManager : Node2D
{
	private PackedScene SunPotScene;
	//private Physics2DShapeQueryParameters Parameters;
	//private Array<Sunpot> Sun
	public override void _Ready()
	{	
		//Parameters.CollisionLayer = 1;
		//Parameters.
		
		SunPotScene = GD.Load<PackedScene>("res://Scenes/Sunpot.tscn");
		AddToGroup("Inputs");
	}
	
	public void OnLeftMouseClick()
	{
		var SpaceState  = GetWorld2d().DirectSpaceState;
		
		Vector2 MousePos = GetGlobalMousePosition();
		
		Physics2DShapeQueryParameters Parameters = new Physics2DShapeQueryParameters();
		RectangleShape2D Shape = new RectangleShape2D();
		Shape.Extents = new Vector2(16,16); // Don't hate me.
		Parameters.SetShape(Shape);
		Parameters.Transform = new Transform2D(0.0f, MousePos);

		//Need to trace up/down and left/right based on the size of the object we are placing aka pot
		var result = SpaceState.IntersectShape(Parameters);
		
		if (result.Count == 0)
		{
			Node SunPotNode = SunPotScene.Instance();
			Node2D SunPotNode2D = (Node2D)SunPotNode;
			SunPotNode2D.Position = MousePos;
			AddChild(SunPotNode2D);
		}
	}
}
