using KnightChall.Domain.DBModels;
using KnightChall.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightChall.Infra.Repository
{
    public class KnightDbRepository : IBaseRepository
    {
        //crud/getlist/getbyid
        private readonly IKnightDbContext _context;
        public KnightDbRepository(IKnightDbContext context)
        {
            _context = context;
        }
        public IList<Knight> Select(string filter)
        {
            switch (filter)
            {
                case "heroes":
                    return _context.hallOfHeroesCollection.Find(k => true).ToList();
                case "knights":
                    return _context.collection.Find(k => true).ToList();
                default:
                    return _context.collection.Find(k => k._id == filter).ToList();
            }
        }
        //falta fazer knight pra hall of heroes
        public void Insert(Knight knight)
        {
            _context.collection.InsertOne(knight);
        }
        public void Delete(string Id)
        {
            //IClientSessionHandle handler = _context.client.StartSession();

            //handler.StartTransaction();
            Knight knight = _context.collection.Find(k => k._id == Id).FirstOrDefault();
            if (knight != null)
            {
                _context.hallOfHeroesCollection.InsertOne(knight);
            }
            _context.collection.DeleteOne(k => k._id == Id);
            //handler.CommitTransaction();


            //handler.AbortTransaction();

        }
        public void Update(string Id, string nickname)
        {
            var filter = Builders<Knight>.Filter.Eq(k => k._id, Id);
            var update = Builders<Knight>.Update.Set(k => k.nickname, nickname);
            _context.collection.UpdateOne(filter, update);
        }

    }
}
