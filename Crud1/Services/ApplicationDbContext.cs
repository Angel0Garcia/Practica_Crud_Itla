﻿using Microsoft.EntityFrameworkCore;

namespace Crud1.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}