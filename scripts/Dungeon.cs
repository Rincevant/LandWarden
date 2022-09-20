using Godot;
using System;

public class Dungeon : Node2D
{ 
    private int MAP_WIDTH = 5;
    private int MAP_HEIGHT = 9;

    private int DUNGEON_SIZE;

    private int NB_ROOMS;

    // La camera est representer par des coordonnee;
    private int cameraX;
    private int cameraY;

    public override void _Ready()
    {         
		this.NB_ROOMS = 4;		
		this.DUNGEON_SIZE = 3;

        // Init dungeon
		Map map = new Map(MAP_HEIGHT * DUNGEON_SIZE, MAP_WIDTH * DUNGEON_SIZE, NB_ROOMS);
		map.initMap();

        cameraX = (int) Math.Floor(map.entry.x / MAP_WIDTH);
		cameraY = (int) Math.Floor(map.entry.y / MAP_HEIGHT);        
        
        GD.Print(cameraX + " " + cameraY);
        GD.Print(map.entry.x + " " + map.entry.y);
        
        for (int i = 0; i < MAP_HEIGHT ; i++)
        {
            for (int j = 0; j < MAP_WIDTH ; j++)
            {
				Case dungeonCase = new Case();
                dungeonCase.Name = "CaseTest";
                dungeonCase.SetPosition(new Vector2((j * 100) + 50, (i * 100) + 50 ));
                dungeonCase.Texture = (Texture)GD.Load(getDungeonTexture(map.mapValues[(cameraY * MAP_HEIGHT) + i, (cameraX * MAP_WIDTH) + j]));
                this.AddChild(dungeonCase);
            }			
        }
        
        // DISPLAY IN CONSOLE
        string lineToPrint = "";	
		for (int i = 0; i < map.height ; i++)
        {
            for (int j = 0; j < map.width; j++)
            {
				if (map.mapValues[i,j] != 0) {
                	lineToPrint += (map.mapValues[i,j] + "|");
				} else {
					lineToPrint += (" " + "|");
				}

            }
            GD.Print(lineToPrint);
            lineToPrint= "";
        }
        
    }

    private string getDungeonTexture(int dungeonValue)
    {
        switch (dungeonValue)
        {
            case 0:
            return "res://images/greystone.png";            
            case 1:
            return "res://images/leaves_orange.png";
            case 2:
            return "res://images/oven.png";
            case 3:
            return "res://images/oven.png";
            default:
            return "";
        }
    }
}
