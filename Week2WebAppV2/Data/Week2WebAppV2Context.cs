using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Week2WebAppV2.Models;

namespace Week2WebAppV2.Data
{
    public class Week2WebAppV2Context : DbContext
    {
        public Week2WebAppV2Context (DbContextOptions<Week2WebAppV2Context> options)
            : base(options)
        {
        }

        public DbSet<Week2WebAppV2.Models.Candle> Candle { get; set; }
    }
}
