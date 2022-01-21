using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transfer.Models;

namespace Transfer.Data
{
    public class SqlTransferRepo : ITransferRepo
    {
        private readonly TransferContext _context;

        public SqlTransferRepo(TransferContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {

            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
        }

        public void Dbupdate(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands(int p)
        {
            return _context.Commands.ToPagedList(p,10);
        }
        public Command GetCommandById(int Id)
        {
            return _context.Commands.FirstOrDefault(p => p.id == Id);
        }
        public IEnumerable<Command> GetCommandBySearch(string search, int p)
        {

            return _context.Commands.Where(p => p.name.Contains(search) || p.desc.Contains(search)).ToPagedList(p,10);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        public void UpdateCommand(Command cmd)
        {
            //Nothing
        }
    }
}
