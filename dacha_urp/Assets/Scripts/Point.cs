using UnityEngine;

public class Position
{
     public float X;
     public float Y;

     public override string ToString()
     {
          return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
     }

     
     public static implicit operator Vector3(Position p) => new Vector3(p.X, 0 ,p.Y);
}

public class BoundPoint
{
     public int Id;
     public Position Position;

     public static implicit operator Vector3(BoundPoint p) => new Vector3(p.Position.X, 0 ,p.Position.Y);

     public override string ToString()
     {
          return $"{nameof(Id)}: {Id}, {nameof(Position)}: {Position}";
     }
}

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
