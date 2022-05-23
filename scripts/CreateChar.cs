using Godot;
using System;

public class CreateChar : Node2D
{
    private Hero hero;

    private string heroName = "";

    private Sprite frameChar;
    public override void _Ready()
    {
        frameChar = GetNode<Sprite>("FrameChar");
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
            heroTexture.Load("res://images/warriorFull.jpg");
            break;
        case "Mage":
            this.hero = new Mage("");
            heroTexture.Load("res://images/mageFull.jpg");
            break;
        case "Rogue":
            this.hero = new Rogue("");
            heroTexture.Load("res://images/rogueFull.jpg");
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
            GD.Print("Creation d'un : " + this.hero + " avec le nom de : " + this.hero.name);
        }
    }
}
