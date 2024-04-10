using KnightChall.Domain.DBModels;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightChall.Domain.Interfaces
{
    public interface IBaseRepository
    {
        void Insert(Knight obj);

        void Update(string Id, string name);

        void Delete(string Id);

        IList<Knight> Select(string filter);
    }
}
