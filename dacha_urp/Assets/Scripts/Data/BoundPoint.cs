using Data;
using UnityEngine;

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