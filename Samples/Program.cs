using NetTopologySuite.Geometries;


var points = "51.437528522926868 35.764087151092724, 51.351353931282532 35.75211166651917, 51.299855171335693 35.716453045689214, 51.329724452104848 35.66321401638271, 51.444738349319422 35.6587525895871, 51.498983709796711 35.7278766857462, 51.47472418359051 35.74706238183694, 51.437528522926868 35.764087151092724";
var data = points.Split(' ', StringSplitOptions.TrimEntries);

for (int i = 0; i < data.Length; i++)
{
    data[i] = data[i].Replace(",", "");
    //data[i] = data[i].Remove(data[i].IndexOf(".") + 7);
}

List<Coordinate> polygonVertices = new List<Coordinate>();
for (int i = 0; i < data.Length; i += 2)
{
    polygonVertices.Add(new Coordinate(Convert.ToDouble(data[i+1]), Convert.ToDouble(data[i])));
}

GeometryFactory geometryFactory = new GeometryFactory();
Polygon poly = geometryFactory.CreatePolygon(polygonVertices.ToArray());

var inside = poly.Contains(new Point(35.699932086378276, 51.34148217446454));
Console.WriteLine(inside ? "Inside" : "Outside");



Console.ReadKey();