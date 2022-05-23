using Godot;
using System;

public class Main : Node2D
{
    public override void _Ready()
    {
        
    }

    public void _on_NewGame_pressed() {
        GetTree().ChangeScene("res://scenes/CreateChar.tscn");
    }

    public void _on_Quit_pressed() 
    {
        GetTree().Quit();
    }
}
