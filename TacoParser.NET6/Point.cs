using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoParser.NET6;
public struct Point
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }

    public Point(double lat, double lon)
    {
        Latitude = lat;
        Longitude = lon;
    }
}
