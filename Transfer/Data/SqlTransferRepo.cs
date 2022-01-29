using System;
using System.Collections.Generic;
using System.Linq;
using Transfer.Dtos;
using Transfer.Helpers;
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
        public PagedList<Command> GetAllCommands(PaginationParams parameters)
        {
            return PagedList<Command>.ToPagedList(_context.Commands, parameters.Page, parameters.ItemsPerPage);
        }
        public Command GetCommandById(int Id)
        {
            return _context.Commands.FirstOrDefault(p => p.id == Id);
        }
        public PagedList<Command> GetCommandBySearch(string search, PaginationParams parameters)
        {
            return PagedList<Command>.ToPagedList(_context.Commands.Where(p => p.name.Contains(search) || p.desc.Contains(search)),parameters.Page, parameters.ItemsPerPage);
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