﻿using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Data
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}
