using Godot;
using System;

public partial class CreateChar : Node2D
{
    private Hero hero;

    private Progression progression;

    private string heroName = "";

    private Sprite2D frameChar;
    public override void _Ready()
    {
        progression = Progression.GetInstance();
        frameChar = GetNode<Sprite2D>("FrameChar");
    }

    public void _on_NameChar_text_changed() {
        this.heroName = GetNode<TextEdit>("NameChar").Text;
    }

    public void _on_Classe_pressed(string classe) 
    {
        ImageTexture heroTexture = new ImageTexture();  
        switch(classe) 
        {
        case "Warrior":
            this.hero = new Warrior("");
            heroTexture.SetImage(Image.LoadFromFile("res://images/warriorFull.jpg")); 
            break;
        case "Mage":
            this.hero = new Mage("");
            heroTexture.SetImage(Image.LoadFromFile("res://images/mageFull.jpg"));
            break;
        case "Rogue":
            this.hero = new Rogue("");
            heroTexture.SetImage(Image.LoadFromFile("res://images/rogueFull.jpg"));
            break;
        default:            
            break;
        }
        frameChar.Texture = heroTexture;
    }

    public void _on_Start_pressed() 
    {
        if (this.hero == null || this.heroName.Equals("") || this.heroName.Length < 3 ) {
            GD.Print("Impossible de creer le hero....");
        } else {
            this.hero.name = this.heroName;
            progression.setHero(this.hero);
            Utils.saveGame();
        }
    }
}
