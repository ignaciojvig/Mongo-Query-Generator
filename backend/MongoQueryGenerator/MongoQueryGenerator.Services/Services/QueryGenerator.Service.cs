using MongoDB.Driver;
using MongoQueryGenerator.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoQueryGenerator.Services
{
    public class QueryGeneratorService
    {
        private readonly IMongoCollection<BookSchema> _books;

        public QueryGeneratorService(IMongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<BookSchema>(settings.CollectionName);
        }
        public List<BookSchema> Get() => _books.Find(book => true).ToList();
        public Object GetQuery() => _books.Find(book => true).ToString();
        public BookSchema Get(string id) => _books.Find(book => book.Id == id).FirstOrDefault();
        public BookSchema Create(BookSchema book)
        {
            _books.InsertOne(book);
            return book;
        }
        public void Update(string id, BookSchema bookIn) => _books.ReplaceOne(book => book.Id == id, bookIn);
        public void Remove(BookSchema bookin) => _books.DeleteOne(book => book.Id == bookin.Id);
        public void Remove(string id) => _books.DeleteOne(book => book.Id == id);
    }
}
