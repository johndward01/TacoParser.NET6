using GeoCoordinatePortable;
using TacoParser.NET6;

ILog logger = new TacoLogger();
const string csvPath = "TacoBell-US-AL.csv";
const double MetersToMiles = 0.00062137;

logger.LogInfo("Log initialized");

var lines = File.ReadAllLines(csvPath);

logger.LogInfo($"Lines: {lines[0]}");

ITrackable tacoBell1 = null;
ITrackable tacoBell2 = null;
double finalDistance = 0;
double testDistance = 0;
var geo1 = new GeoCoordinate();
var geo2 = new GeoCoordinate();

// Transforms each line (string) to an ITrackable object and saves it to the locations array
var locations = lines.Select(Parser.Parse).ToArray();

for (int i = 0; i < locations.Length; i++)
{
    geo1.Latitude = locations[i].Location.Latitude;
    geo1.Longitude = locations[i].Location.Longitude;

    for (int j = 1; j < locations.Length; j++)
    {
        geo2.Latitude = locations[j].Location.Latitude;
        geo2.Longitude = locations[j].Location.Longitude;

        testDistance = geo1.GetDistanceTo(geo2);

        if (finalDistance < testDistance)
        {
            finalDistance = testDistance;
            tacoBell1 = locations[i];
            tacoBell2 = locations[j];
        }
    }
}
//logger.LogInfo($"{tacoBell1.Name} and {tacoBell2.Name}");

Console.WriteLine($"The 2 furthest {tacoBell1.GetType().Name}'s are {tacoBell1.Name} and {tacoBell2.Name}.");
Console.WriteLine($"The total distance is {Math.Round((finalDistance * MetersToMiles), 2)} miles.");