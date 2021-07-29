using UnityEngine;

namespace Data
{
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
}