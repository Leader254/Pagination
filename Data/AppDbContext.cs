﻿using Microsoft.EntityFrameworkCore;
using Pagination.Models;

namespace Pagination.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
    }
}
