using Godot;
public partial class Map {
    public int width;
    public int height;

    public int nb_rooms;

    public int[,] mapValues;

    public Room[] rooms = null;

    public Vector2 entry = new Vector2(0,0);

    public Vector2 exit = new Vector2(0,0);

    public Map(int h, int w, int nb_rooms) 
    {
        this.width = w;
        this.height = h;
        this.mapValues = new int[h, w];
        this.nb_rooms = nb_rooms;        
    }

    public void initMap() 
    {    
        this.rooms = new Room[nb_rooms];
        this.entry = new Vector2(0,0);
        this.exit = new Vector2(0,0);

        if (this.mapValues == null ){
            return;
        }

        // Init map with with 0 values
        for (int i = 0; i < this.height; i++)
        {
            for (int j = 0; j < this.width; j++)
            {
                this.mapValues[i,j] = 0;
            }
        }

        if ( (this.width * this.height) < (nb_rooms * (5*5) )) {
            return;
        }

        // Create rooms
        createAllRooms();

        // Create connections;
        connectAllRooms();

        // Setup entry
        this.entry = setupSquareWithUniqueValue(2);

        // Setup exit
        this.exit = setupSquareWithUniqueValue(3); 

        // If same entry and exit
        if (this.entry.X == this.exit.X && this.entry.Y == this.exit.Y) {            
            initMap();
        }
    }

    public bool isRoomIntersects(Room roomToCreate) {
        foreach (Room room in this.rooms)
        {
            if (room != null && roomToCreate.intersects(room)) {
                return true;
            }
        }
        return false;
    }

    public void addRoomToMap(Room room)
    {
        for (int i = room.y1; i < room.y2; i++)
        {
            for (int j = room.x1; j < room.x2; j++)
            {
                this.mapValues[i,j] = 1;
            }
        }
    }

    public void connectTwoRooms(Room room1, Room room2) {        
        Vector2 centerR1 = room1.center;
        Vector2 centerR2 = room2.center;

        // Connect on X
        if (centerR1.X < centerR2.X) {
            for ( float i = centerR1.X; i < centerR2.X; i++)
            {
                this.mapValues[(int)centerR1.Y, (int) i] = 1;
            }            
        } else if (centerR1.X > centerR2.X) {
            for (float i = centerR1.X; i > centerR2.X; i--)
            {
                this.mapValues[(int) centerR1.Y, (int) i] = 1;
            }
        }

        // Connect on Y
        if (centerR1.Y < centerR2.Y) {
            for (float i = centerR1.Y; i < centerR2.Y; i++)
            {
                this.mapValues[(int) i , (int) centerR2.X] = 1;
            }
        } else if (centerR1.Y > centerR2.Y) {
            for (float i = centerR1.Y; i > centerR2.Y; i--)
            {
                this.mapValues[(int) i, (int) centerR2.X] = 1;
            }
        }        
    }

    private void createAllRooms()
    {
        var rnd = new RandomNumberGenerator();        
        for (int i = 0; i < this.nb_rooms; i++)
		{
            rnd.Randomize();
			int x = rnd.RandiRange(0,this.width - 5);
			int y = rnd.RandiRange(0, this.height - 5);
			Room room = new Room(x, y, 5, 5);

			if (this.isRoomIntersects(room)) {
                GD.Print("intersection...");
				i--;
			} else {
				this.rooms[i] = room;
				this.addRoomToMap(room);
			}
		}
    }

    private void connectAllRooms() 
    {
        for (int i = 0; i < this.nb_rooms - 1; i++)
		{
			this.connectTwoRooms(this.rooms[i], this.rooms[i+1]);
		}
    }

    private Vector2 setupSquareWithUniqueValue(int uniqueValue)
    {
        // The unique value represent the kind of square ex : 2 for entry / 3 for exit
        
        var rnd = new RandomNumberGenerator();
        rnd.Randomize(); 
        int randomRoom = rnd.RandiRange(0,this.nb_rooms - 1);
        Vector2 randomPoint = new Vector2(rnd.RandiRange(0,4), rnd.RandiRange(0,4));       
        this.mapValues[this.rooms[randomRoom].y1 + (int) randomPoint.Y, this.rooms[randomRoom].x1 + (int) randomPoint.X] = uniqueValue;

        return new Vector2(this.rooms[randomRoom].x1 + randomPoint.X, this.rooms[randomRoom].y1 + randomPoint.Y);
    }
}