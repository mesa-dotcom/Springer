using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Springer.Models
{
    public class Device
    {
        public string StoreId { get; set; }
        public string Name { get; set; }
        public string No { get; set; }
        public string IP { get; set; }
        public bool IsAlive { get; set; } = false;
    }
}
