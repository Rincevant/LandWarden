using Godot;
using System;
public partial class Room {

    // these values hold grid coordinates for each corner of the room
    public int x1;
    public int x2;
    public int y1;
    public int y2;
 
    // width and height of room in terms of grid
    public int w;
    public int h;
 
    // center point of the room
    public Vector2 center;
 
    // constructor for creating new rooms
    public Room (int x, int y, int w, int h) {
        
        this.x1 = x;
        this.x2 = x + w;
        this.y1 = y;
        this.y2 = y + h;
        
        this.w = w;
        this.h = h;
        center = new Vector2(Mathf.Floor( (x1 + x2) / 2), Mathf.Floor( (y1 + y2) / 2));
    }
 
    // return true if this room intersects provided room
    public bool intersects(Room room) {
        return (this.x1 <= room.x2 && this.x2 >= room.x1 &&
            this.y1 <= room.y2 && this.y2 >= room.y1);
    }
}