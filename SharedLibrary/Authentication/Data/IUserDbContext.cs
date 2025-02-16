using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itvidpradotnetcoreadvanced;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Authorization;

namespace SharedLibrary.Authentication.Data
{
    public interface IUserDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<UserLogin> UserLogins { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
