using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MaineCoon.Models;

namespace MaineCoon.Data
{
    public class MaineCoonContext : DbContext
    {
        public MaineCoonContext (DbContextOptions<MaineCoonContext> options)
            : base(options)
        {
        }

        public DbSet<MaineCoon.Models.StudentScore> StudentScore { get; set; }

        public DbSet<MaineCoon.Models.QuestRecord> QuestRecord { get; set; }
        public DbSet<MaineCoon.Models.User> User { get; set; }
        public DbSet<MaineCoon.Models.Processer> Processers { get; set; }
    }
}
