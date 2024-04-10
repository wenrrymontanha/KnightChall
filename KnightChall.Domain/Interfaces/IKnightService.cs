using KnightChall.Domain.DBModels;
using KnightChall.Domain.DTO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightChall.Domain.Interfaces
{
    public interface IKnightService
    {
        Knight Add(DTOKnight obj);

        void Delete(string id);

        Knight GetId(string Id);
        IList<DTOKnightList> Get(string filter);

        Knight Update(string Id, string name);
    }
}
