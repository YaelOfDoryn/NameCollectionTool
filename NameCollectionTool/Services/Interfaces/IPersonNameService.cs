using NameCollectionTool.Dtos;

namespace NameCollectionTool.Services.Interfaces
{
    public interface IPersonNameService
    {
        List<PersonNameDto> GetAllPersonNames();
        void InsertNewName(PersonNameDto name);
        void DeleteName(int id);
        void UpdateName(PersonNameDto name);
    }
}
