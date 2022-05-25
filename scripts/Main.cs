using Godot;
using Godot.Collections;
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

    public void _on_Load_pressed() 
    {
        Utils.loadGame();

        Progression prog = Progression.GetInstance();
        GD.Print(prog.getHero().name);
        GD.Print(prog.getHero().GetType());
    }
}
