using System.Collections.Generic;
using Transfer.Dtos;
using Transfer.Models;

namespace Transfer.Data
{
    public interface ITransferRepo
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands(int p);
        Command GetCommandById(int Id);
        IEnumerable<Command> GetCommandBySearch(string search, int p);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
        void Dbupdate(Command cmd);
    }
}
