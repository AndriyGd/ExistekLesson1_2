namespace Lesson8.Generics
{
    public class Point<TCord> where TCord: struct
    {
        public TCord X { get; set; }
        public TCord Y { get; set; }

        public override string ToString()
        {
            return $"X: {X} Y: {Y}\n";
        }
    }
}
