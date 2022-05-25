using Godot;
public static class Utils
{
    public static void saveGame()
    {   
        Progression progression = Progression.GetInstance();

        var saveData = new Godot.Collections.Dictionary<string, object>()
        {
            { "heroName", progression.getHero().name },
            { "heroClasse" , progression.getHero().GetType().ToString() }
        };
        var saveGame = new File();
        saveGame.OpenEncryptedWithPass("user://savegame.save", File.ModeFlags.Write, "mypass");
        saveGame.StoreLine(JSON.Print(saveData));
        saveGame.Close();
    }

    public static void loadGame() {
        var saveGame = new File();
        if (!saveGame.FileExists("user://savegame.save"))return; 
        saveGame.OpenEncryptedWithPass("user://savegame.save", File.ModeFlags.Read, "mypass");        
           
        var saveData = new Godot.Collections.Dictionary<string, object>((Godot.Collections.Dictionary)JSON.Parse(saveGame.GetLine()).Result);
        
        Progression progression = Progression.GetInstance();

        // Load Hero
        Hero hero = Utils.createHeroFromLoad(saveData);
        progression.setHero(hero);

        saveGame.Close();
    }

    private static Hero createHeroFromLoad(Godot.Collections.Dictionary<string, object> data)
    {
        Hero hero = null;
        switch(data["heroClasse"]) 
        {
        case "Warrior":
            hero = new Warrior("");            
            break;
        case "Mage":
            hero = new Mage("");            
            break;
        case "Rogue":
            hero = new Rogue("");            
            break;
        default:            
            break;
        }

        if (hero != null) {
            hero.name = data["heroName"].ToString();
        }

        return hero;
    }
}