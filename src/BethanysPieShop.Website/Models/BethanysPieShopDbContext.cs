﻿using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Website.Models
{
    public class BethanysPieShopDbContext : DbContext
    {
        public BethanysPieShopDbContext(
            DbContextOptions<BethanysPieShopDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }
    }
}