using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MaineCoon.Models;

namespace MaineCoon.Data
{
    public class StudentScoreContext : DbContext
    {
        public StudentScoreContext (DbContextOptions<StudentScoreContext> options)
            : base(options)
        {
        }

        public DbSet<MaineCoon.Models.StudentScore> StudentScore { get; set; }
    }
}
