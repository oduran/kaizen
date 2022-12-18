namespace OcrPointWinForms
{
    public class OcrPoint
    {
        public string Description { get; set; }
        public BoundingPolicy BoundingPoly { get; set; }
        public string? Locale { get; set; }
    }
    public class BoundingPolicy
    {
        public List<Vertices> Vertices { get; set; }
    }
    public class Vertices
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
