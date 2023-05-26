﻿using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //difines the table that will be create by the EntityFrameworkCore
        public DbSet<Category> Categories { get; set; }
        public DbSet<Snack> Snacks { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

    }
}
