using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MaineCoon.Models;

namespace MaineCoon.Data {
    public class UserContext : DbContext {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options) {
        }

        public DbSet<MaineCoon.Models.User> User { get; set; }
    }
}
