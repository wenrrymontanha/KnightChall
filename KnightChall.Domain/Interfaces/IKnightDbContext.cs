using KnightChall.Domain.DBModels;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightChall.Domain.Interfaces
{
    public interface IKnightDbContext
    {
        public MongoClient client { get; }
        public IMongoDatabase database { get; }
        public IMongoCollection<Knight> collection { get; }
        public IMongoCollection<Knight> hallOfHeroesCollection { get; }
    }
}
