using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FormProcessorApi.Models
{
    public class FormDetailsContext : DbContext
    {
        public FormDetailsContext (DbContextOptions<FormDetailsContext> options)
            : base(options)
        {
        }

        public DbSet<FormProcessorApi.Models.FormDetails> FormDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=formdetails.db");
        }
    }
}
