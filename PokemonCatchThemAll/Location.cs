using System;

namespace PokemonCatchThemAll
{
    public class Location : IEquatable<Location>
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }

        public Location(int coordinateX, int coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }

        public string GetLocation()
        {
            return ($"({CoordinateX},{CoordinateY})");
        }

        public bool Equals(Location obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Location location = (Location)obj;
                return (CoordinateX == location.CoordinateX) && (CoordinateY == location.CoordinateY);
            }
        }
    }
}
