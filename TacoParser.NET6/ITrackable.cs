using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoParser.NET6;
public interface ITrackable
{
    public string Name { get; set; }
    public Point Location { get; set; }


}
