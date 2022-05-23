public class Hero
{
    public string name { get; set; }
    public int pv { get; set; }
    public int mana { get; set; }
    public int frenesie { get; set; }
    public int finesse { get; set; }

    public Hero(string name) {
        this.name = name;
        this.pv = 100;
    }

}