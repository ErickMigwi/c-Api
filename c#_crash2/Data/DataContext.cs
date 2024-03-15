namespace c__crash2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<STUDENT> Students =>Set<STUDENT>();
    }
}
