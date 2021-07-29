using Data;

public class Tree
{
    public int Id;
    public string Type;
    public float Diameter;
    public float Height;
    public Position Position;

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(Type)}: {Type}, {nameof(Diameter)}: {Diameter}, {nameof(Height)}: {Height}, {nameof(Position)}: {Position}";
    }
}