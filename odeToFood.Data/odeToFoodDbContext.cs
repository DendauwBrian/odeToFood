using Microsoft.EntityFrameworkCore;
using odeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace odeToFood.Data
{
    public class odeToFoodDbContext : DbContext
    {
        public odeToFoodDbContext(DbContextOptions<odeToFoodDbContext> options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }

    }
}
