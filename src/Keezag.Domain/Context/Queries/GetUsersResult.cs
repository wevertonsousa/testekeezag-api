using Keezag.Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keezag.Domain.Context.Queries
{
    public class GetUsersResult
    {
        public long TotalSize { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<User> Users { get; set; }
    }
}
