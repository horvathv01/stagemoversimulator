namespace StageMover.Models
{
    internal class Position
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Position(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Z: {Z}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Position
                && ((Position)obj).X == X
                && ((Position)obj).Y == Y
                && ((Position)obj).Z == Z;
        }
    }
}
