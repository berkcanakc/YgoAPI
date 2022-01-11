using Microsoft.EntityFrameworkCore;
using Transfer.Models;

namespace Transfer.Data
{
    public class TransferContext : DbContext
    {
        public TransferContext(DbContextOptions<TransferContext> opt) : base(opt)
        {

        }

        public DbSet<Command> Commands { get; set; }

    }
}
