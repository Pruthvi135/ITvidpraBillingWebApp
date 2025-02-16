using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itvidpradotnetcoreadvanced.Models;
using Microsoft.EntityFrameworkCore;
using itvidpradotnetcoreadvanced.Models;

using SharedLibrary.Authorization;

namespace SharedLibrary.Authentication.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<UserLogin> UserLogins { get; set; }

        // Include other DbSets if needed
        // DbSet<Product> Products { get; set; }
        // DbSet<Order> Orders { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
