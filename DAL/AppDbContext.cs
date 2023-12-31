﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_Pronia.Models;

namespace Project_Pronia.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
        public DbSet<Categories> categories { get; set; }
        public DbSet<ProductImages> productImages { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<ProductTags> productTags { get; set; }
        public DbSet<Slider> sliders { get; set; }
        public DbSet<Tags> tags { get; set; }
        public DbSet<Setting> Settings { get; set; }

    }

}
