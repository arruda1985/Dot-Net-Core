using Agatha.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agatha.Persistence
{
    public class DbContextFactory : DesignTimeDbContextFactoryBase<AgathaDbContext>
    {
        protected override AgathaDbContext CreateNewInstance(DbContextOptions<AgathaDbContext> options)
        {
            return new AgathaDbContext(options);
        }
    }
}
