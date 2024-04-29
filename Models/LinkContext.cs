using Microsoft.EntityFrameworkCore;

namespace HomePageApi.Models;
    public class LinkContext : DbContext
    {
        public LinkContext(DbContextOptions<LinkContext> options)
            : base(options)
        {
        }

        public DbSet<LinkItem> Links { get; set; }
        public DbSet<LinkCategory> Categories { get; set; }
    }
