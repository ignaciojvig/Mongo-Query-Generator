using MongoDB.Driver;
using MongoQueryGenerator.Domain.Interfaces;
using MongoQueryGenerator.Infra.Data.Mongo;
using MongoQueryGenerator.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoQueryGenerator.Services
{
    public class QueryGeneratorService : IQueryGeneratorService
    {
        private readonly IMongoCollection<dynamic> _hypoteticCollection;

        public QueryGeneratorService(IMongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _hypoteticCollection = database.GetCollection<dynamic>(settings.CollectionName);
        }

        public Object GetQuery() => _hypoteticCollection.Find(book => true).ToString();

    }
}
