namespace Samples
{
    public class MyPolygon
    {
        public List<MyPoint> Vertices { get; set; }

        public MyPolygon(List<MyPoint> vertices)
        {
            Vertices = vertices;
        }


        // Ray-Casting Algorithm to check if the point is inside the polygon
        public bool IsPointInside(MyPoint point)
        {
            int vertexCount = Vertices.Count;
            bool isInside = false;

            for (int i = 0, j = vertexCount - 1; i < vertexCount; j = i++)
            {
                double xi = Vertices[i].Longitude, yi = Vertices[i].Latitude;
                double xj = Vertices[j].Longitude, yj = Vertices[j].Latitude;

                bool intersect = ((yi > point.Latitude) != (yj > point.Latitude)) &&
                                 (point.Longitude < (xj - xi) * (point.Latitude - yi) / (yj - yi) + xi);

                if (intersect)
                    isInside = !isInside;
            }

            return isInside;
        }

    }
}
