using Lab8.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<FullName> FullNames { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext()
        {
            if (Database.EnsureCreated())
            {
                Roles.Load();
                Roles.AddRange(_roles);
                SaveChanges();
            }
            else
            {
                Roles.Load();
            }
            FullNames.Load();
            Users.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Lab8");
        }
        private List<Role> _roles = new List<Role>()
        {
            new Role()
            {
                MainRole = Lab8.Model.Roles.admin
            },
            new Role()
            {
                MainRole = Lab8.Model.Roles.master
            },
            new Role()
            {
                MainRole = Lab8.Model.Roles.user
            },
            new Role()
            {
                MainRole = Lab8.Model.Roles.manager
            },
        };
    }
}
