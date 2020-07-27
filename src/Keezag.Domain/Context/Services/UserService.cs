using Keezag.Domain.Context.Entities;
using Keezag.Domain.Context.Interfaces;
using Keezag.Domain.Context.Queries;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keezag.Domain.Context.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) => _userRepository = userRepository;

        public User Create(User user) => _userRepository.Create(user);

        public User Get(string id) => _userRepository.Get(id);

        public User GetByEmail(string email) => _userRepository.GetByEmail(email);

        public GetUsersResult Get(int page, int pageSize) => _userRepository.Get(page, pageSize);

        public void Remove(User userIn) => _userRepository.Remove(userIn);

        public void Remove(string id) => _userRepository.Remove(id);

        public void Update(string id, User userIn) => _userRepository.Update(id, userIn);
    }
}
