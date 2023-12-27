using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi009.Models;

namespace WebApi009.Data
{
    public class WebApi009Context : DbContext
    {
        public WebApi009Context (DbContextOptions<WebApi009Context> options)
            : base(options)
        {
        }

        public DbSet<WebApi009.Models.student> student { get; set; } = default!;
    }
}
