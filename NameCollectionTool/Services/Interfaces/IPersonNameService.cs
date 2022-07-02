using NameCollectionTool.Dtos;
using NameCollectionTool.Models;

namespace NameCollectionTool.Services.Interfaces
{
    public interface IPersonNameService
    {
        List<PersonNameDto> GetAllPersonNames();
        void InsertNewName(PersonNameViewModel name);
        public void InsertNewNames(List<PersonNameDto> newSet);
        void DeleteName(int id);
        void UpdateName(PersonNameViewModel name);
    }
}
