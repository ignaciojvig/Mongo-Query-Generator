using MongoDB.Driver;
using MongoQueryGenerator.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoQueryGenerator.Domain.Interfaces
{
    public interface IQueryGeneratorService
    {
        public List<BookSchema> Get();
        public Object GetQuery();
        public BookSchema Get(string id);
        public BookSchema Create(BookSchema book);
        public void Update(string id, BookSchema bookIn);
        public void Remove(BookSchema bookin);
        public void Remove(string id);
    }
}
