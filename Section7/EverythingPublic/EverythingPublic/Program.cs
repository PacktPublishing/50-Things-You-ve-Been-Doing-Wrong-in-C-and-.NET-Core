using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EverythingPublic
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blogging.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //choose one below
            modelBuilder.Entity<Blog>()
            .Property(p => p.Url)
            .IsConcurrencyToken();

            modelBuilder.Entity<Blog>()
           .Property(p => p.Timestamp)
           .IsRowVersion();

            modelbuilder.HasSequence<int>("DBSequenceHiLo").StartsAt(1000).IncrementsBy(5);
            modelbuilder.ForSqlServerUseSequenceHiLo("DBSequenceHiLo");
        }

    }

    public class Blog
    {
        public int Id { get; private set; }
        public string Url { get; set; }

        //use if you want row versioning.
        public byte[] Timestamp { get; set; }
    }

  
    class Program
    {
        static async Task Main(string[] args)
        {
            await ProcessBlog();

            var t1 = ProcessBlogConcurrent();
            var t2 = ProcessBlogConcurrent();
            await Task.WhenAll(t1, t2);
        }

        static async Task ProcessBlog()
        {
            using (var db = new BloggingContext())
            //if you need explicit transaction support.
            using (await db.Database.BeginTransactionAsync())
            {
                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });

                var count = await db.SaveChangesAsync();

                var blogs = await db.Blogs.Where(b => !b.Url.EndsWith("/")).ToListAsync();

                foreach (var blog in blogs)
                {
                    blog.Url += "/";
                }

                await db.SaveChangesAsync();

                db.Database.CommitTransaction();
            }
        }

        static async Task ProcessBlogConcurrent()
        {
            var random = new Random(Thread.CurrentThread.ManagedThreadId);
            try
            {
                await ProcessBlog();
            }
            catch(DbUpdateConcurrencyException)
            {
                await Task.Delay(random.Next(100));
                await ProcessBlogConcurrent();
            }
        }
    }
}
