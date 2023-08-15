using Insttant.DataAccess.Repositories;
using Insttantt.Domain.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.DataAccess.Repositories
{
    public class MongoRepository<T> : IMongoRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IOptions<MongoConfiguration> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<T>(typeof(T).Name);
        }

        public async Task<T> Insert(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task InsertRange(List<T> entities)
        {
            await _collection.InsertManyAsync(entities);
        }
    }
}
