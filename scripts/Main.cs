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

    private string SAVE_DIR = "res://saves/";
    private string save_path = "res://saves/save.dat";


    public void _on_Save_pressed()
    {
	    var saveData = new Godot.Collections.Dictionary<string, object>()
        {
            { "Score", "123" },
            { "test" , "julien"}
        };
        var saveGame = new File();
        saveGame.OpenEncryptedWithPass("user://savegame.save", File.ModeFlags.Write, "mypass");
        saveGame.StoreLine(JSON.Print(saveData));
        saveGame.Close();
    }

    public void _on_Load_pressed() 
    {
        var saveGame = new File();
        if (!saveGame.FileExists("user://savegame.save"))return; 
        saveGame.OpenEncryptedWithPass("user://savegame.save", File.ModeFlags.Read, "mypass");        
           
        var saveData = new Godot.Collections.Dictionary<string, object>((Godot.Collections.Dictionary)JSON.Parse(saveGame.GetLine()).Result);
        var newScore = saveData["Score"].ToString();
        var testValue = saveData["test"].ToString();            
       
        saveGame.Close();
    }
}
