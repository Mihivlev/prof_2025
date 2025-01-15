package com.example.mobilerussionsroads.classes;
public class Events {
    private int ID;
    private String Name;
    private int MakerID;
    private String Description;
    private String Start;
    public Events(int ID, String Name, int MakerID, String Description, String Start){
        this.ID = ID;
        this.Start = Start;
        this.Description = Description;
        this.Name = Name;
        this.MakerID = MakerID;
    }
    public String getDescription() {
        return Description;
    }
    public String getStart() {return Start;}
    public String getName() {return Name;}
    public int getMakerID() {
        return MakerID;
    }
}
