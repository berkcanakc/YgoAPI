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

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }
        public Command GetCommandById(int Id)
        {
            return _context.Commands.FirstOrDefault(p => p.id == Id);
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
