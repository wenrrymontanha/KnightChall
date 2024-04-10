using KnightChall.Domain.DBModels;
using KnightChall.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KnightChall.Infra.Context
{
    public class KnightDbContext : IKnightDbContext
    {
        public IMongoDatabase database { get; private set; }
        public MongoClient client { get; private set; }
        public IMongoCollection<Knight> collection { get; private set; }
        public IMongoCollection<Knight> hallOfHeroesCollection { get; private set; }
        public KnightDbContext()
        {
            client = new MongoClient("mongodb://mongo:27017");
            database = client.GetDatabase("KnightsDb");
            collection = database.GetCollection<Knight>("Knights");
            hallOfHeroesCollection = database.GetCollection<Knight>("HallOfHeroes");
        }
    }
}
