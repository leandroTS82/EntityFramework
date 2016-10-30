using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Models;

namespace Data.Entity
{
    public class DataEntity : DbContext
    {
        public DataEntity()
            : base("Name=connectString")
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
        }
        public DbSet<Emails> Emails { get; set; }
    }
}
