using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Exercise.Models
{
    public class IdentityModel
    {
        public class ApplicationDbContext : DbContext
        {
            public DbSet<Customers> Customers { get; set; }
            public DbSet<Movies> Movies { get; set; }
            public DbSet<MembershipType> MembershipTypes { get; set; }
            public DbSet<MoviesGenre> MoviesGenres { get; set; }
        }
    }
}