using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Data.Entities;

namespace webAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> dbop ) : base(dbop)
        {

        }

        public DbSet<Music> Music { get; set; }
    }
}
