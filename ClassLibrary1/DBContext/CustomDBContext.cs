using CoreEntities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace SqlServerPlugin
{
    public class CustomDBContext : DbContext
    {
        public CustomDBContext(DbContextOptions<CustomDBContext> options) : base(options) { }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        

    }
}