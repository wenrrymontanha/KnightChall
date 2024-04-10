using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightChall.Domain.DBModels
{   

    public class Knight
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string birthday { get; set; }
        public List<Weapon> weapons { get; set; }
        public Attributes attributes { get; set; }
        public string keyAttribute { get; set; }
    }   


}
