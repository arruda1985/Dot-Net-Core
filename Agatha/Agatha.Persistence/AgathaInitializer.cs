using System;
using System.Collections.Generic;
using System.Text;

namespace Agatha.Persistence
{
    public class AgathaInitializer
    {
        public static void Initialize(AgathaDbContext context)
        {
            var initializer = new AgathaInitializer();
            initializer.SeedEverything(context);
        }
        public void SeedEverything(AgathaDbContext context)
        {
            context.Database.EnsureCreated();

        }
    }
}
