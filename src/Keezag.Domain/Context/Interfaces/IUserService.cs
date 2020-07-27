using Keezag.Domain.Context.Entities;
using Keezag.Domain.Context.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keezag.Domain.Context.Interfaces
{
    public interface IUserService
    {
        GetUsersResult Get(int page, int pageSize);
        User Get(string id);
        User GetByEmail(string email);
        User Create(User user);
        void Update(string id, User userIn);
        void Remove(User userIn);
        void Remove(string id);
    }
}
