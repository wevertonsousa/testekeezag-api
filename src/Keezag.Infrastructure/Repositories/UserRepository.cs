using Keezag.Domain.Context.Entities;
using Keezag.Domain.Context.Interfaces;
using Keezag.Domain.Context.Queries;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Keezag.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            var client = new MongoClient(_configuration["CosmosDatabase:ConnectionString"]);
            var database = client.GetDatabase(_configuration["CosmosDatabase:DatabaseName"]);
            _users = database.GetCollection<User>(_configuration["CosmosDatabase:CollectionName"]);
        }

        public GetUsersResult Get(int page, int pageSize)
        {
            return new GetUsersResult
            {
                TotalSize = _users.CountDocuments(user => true),
                Page = page,
                PageSize = pageSize,
                Users = _users.Find(user => true).Skip(page * pageSize).Limit(pageSize).ToList()
            };            
        }

        public User Get(string id) =>
            _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User GetByEmail(string email) =>
            _users.Find<User>(user => user.Email == email).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) =>
            _users.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(User userIn) =>
            _users.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) =>
            _users.DeleteOne(user => user.Id == id);
    }
}
