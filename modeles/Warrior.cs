public class Warrior : Hero
{
    public Warrior(string name) : base(name) {        
        this.frenesie = 100;
        
        // Disable other values
        this.mana = 0;
        this.finesse = 0;
    }
}