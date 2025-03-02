using Microsoft.EntityFrameworkCore;
using WpfApp1111.Entities;
using System;
using System.Collections.Generic;
using WpfApp1111.Entities;

namespace WpfApp1111.DatabaseContext
{
    public class ApplicationDbContext : DbContext // Обратите внимание, что класс теперь public
    {
        public DbSet<User> Users { get; set; } = null!; // Свойство Users

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=1234;database=radel;",
                new MySqlServerVersion(new Version(8, 0, 41))
            );
        }
    }
}
