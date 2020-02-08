using Godot;
using System;

public class SunPotManager : Node2D
{
	private PackedScene SunPotScene;
	
	public override void _Ready()
	{	
		SunPotScene = GD.Load<PackedScene>("res://Scenes/Sunpot.tscn");
		AddToGroup("Inputs");
	}
	
	public void OnLeftMouseClick()
	{
		//check if the player has any pots
		//check if any pots are over lapping 
		//spawn the pots
		Node SunPotNode = SunPotScene.Instance();
		Node2D SunPotNode2D = (Node2D)SunPotNode;
		SunPotNode2D.Position = GetGlobalMousePosition();
		AddChild(SunPotNode2D);
	}
}
