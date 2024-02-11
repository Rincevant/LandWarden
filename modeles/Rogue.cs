public partial class Rogue : Hero
{

    public Rogue(string name) : base(name) {
        this.finesse = 100;

        // Disable other values
        this.mana = 0;
        this.frenesie = 0;
    }
}