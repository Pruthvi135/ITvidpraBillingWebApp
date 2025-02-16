using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using Microsoft.EntityFrameworkCore;
using itvidpradotnetcoreadvanced.Models;
using SharedLibrary.Authorization;

namespace SharedLibrary.Authentication.Interfaces
{
    public interface IUserDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<UserLogin> UserLogins { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
