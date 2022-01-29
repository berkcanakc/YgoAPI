using System.Collections.Generic;
using Transfer.Dtos;
using Transfer.Helpers;
using Transfer.Models;

namespace Transfer.Data
{
    public interface ITransferRepo
    {
        bool SaveChanges();

        PagedList<Command> GetAllCommands(PaginationParams parameters);
        Command GetCommandById(int Id);
        PagedList<Command> GetCommandBySearch(string search, PaginationParams parameters);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
        void Dbupdate(Command cmd);
    }
}
