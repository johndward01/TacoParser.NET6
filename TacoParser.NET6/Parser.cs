using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoParser.NET6;

public class Parser
{
    static ILog _logger = new TacoLogger();

    public static ITrackable Parse(string line)
    {
        _logger.LogInfo("Begin parsing");

        if (line == null)
        {
            _logger.LogWarning("Something went wrong: Length less than 3");
            return null;
        }

        var cells = line.Split(',');

        if (cells.Length < 3)
        {
            _logger.LogError("Not enough information to parse");
            return null;
        }

        var latitude = double.Parse(cells[0]);
        var longitude = double.Parse(cells[1]);
        var name = cells[2];

        var tacoBell = new TacoBell(name, latitude, longitude);

        return tacoBell;
    }
}
