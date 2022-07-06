using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemiologyReport.Models;
using Microsoft.EntityFrameworkCore;

namespace EpidemiologyReport.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Patient> patients { get; set; }
    }
}
