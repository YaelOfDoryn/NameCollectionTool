using NameCollectionTool.Dtos;
using NameCollectionTool.Models;

namespace NameCollectionTool.Services.Interfaces
{
    public interface IPersonNameService
    {
        List<PersonNameDto> GetAllPersonNames();
        void InsertNewName(PersonNameViewModel name);
        void DeleteName(int id);
        void UpdateName(PersonNameViewModel name);
    }
}
