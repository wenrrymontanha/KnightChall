using KnightChall.Domain.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightChall.Domain.DTO
{
    public class DTOKnight
    {
        public string name { get; set; }
        public string nickname { get; set; }
        public string birthday { get; set; }
        public List<Weapon> weapons { get; set; }
        public Attributes attributes { get; set; }
        public string keyAttribute { get; set; }
    }
}
