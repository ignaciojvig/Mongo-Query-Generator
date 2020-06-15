using MongoDB.Driver;
using MongoQueryGenerator.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoQueryGenerator.Domain.Interfaces
{
    public interface IQueryGeneratorService
    {
        public Object GetQuery();
    }
}
