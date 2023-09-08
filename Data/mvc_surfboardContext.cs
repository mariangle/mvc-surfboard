using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvc_surfboard.Models;

namespace mvc_surfboard.Data
{
    public class mvc_surfboardContext : DbContext
    {
        public mvc_surfboardContext (DbContextOptions<mvc_surfboardContext> options)
            : base(options)
        {
        }

        public DbSet<mvc_surfboard.Models.Surfboard> Surfboard { get; set; } = default!;
    }
}
