using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightChall.Domain.DBModels
{
    public class Weapon
    {
        public string name { get; set; }
        public int mod { get; set; }
        public string attr { get; set; }
        public bool equipped { get; set; }
    }
}
