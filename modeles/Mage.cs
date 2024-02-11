public partial class Mage : Hero
{
    public Mage(string name) : base(name) {
        this.mana = 100;
        
        // Disable other values
        this.frenesie = 0;
        this.finesse = 0;
    }
        
}