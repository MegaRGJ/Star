using Godot;
using System;

public class CharacterAnim : Sprite
{
	private Character CharacterInput;
	private AnimationPlayer Player;
	
	public override void _Ready()
	{
		CharacterInput = (Character)GetParent();
		Player = GetNode<AnimationPlayer>("AnimationPlayer");
		Player.Play("Idle");
		
		//CharacterInput = GetNode<Character>("Character");
	}

  public override void _Process(float delta)
  {
	bool NotMoving = true;
	
	if(CharacterInput.MoveRight)
	{
		Player.Play("WalkRight");
		NotMoving = false;
	}
	
	if(CharacterInput.MoveLeft)
	{
		Player.Play("WalkRight");
		NotMoving = false;
	}
	
	if(CharacterInput.MoveUp)
	{
		Player.Play("WalkRight");
		NotMoving = false;
	}
	
	if(CharacterInput.MoveDown)
	{
		Player.Play("WalkRight");
		NotMoving = false;
	}
	
	if (NotMoving)
	{
		Player.Play("Idle");
	}
  }

}
