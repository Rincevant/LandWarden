  using Godot;
  public sealed class Progression
    {        
        private Hero hero;
        private Progression() { }
        
        private static Progression _instance;
       
        public static Progression GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Progression();
            }
            return _instance;
        }
        
        public void someBusinessLogic()
        {
            GD.Print("Bsuiness logic");
        }

        public void setHero(Hero hero) 
        {
            this.hero = hero;
        }

        public Hero getHero() 
        {
            return this.hero;
        }
    }