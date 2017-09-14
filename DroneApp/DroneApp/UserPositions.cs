using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneApp
{
    class UserPositions
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public bool IsUser { get; set; }
        public double Radius { get; set; }
    }
}
