using NameCollectionTool.Dtos;
using NameCollectionTool.Models;

namespace NameCollectionTool.Services.Interfaces
{
    public interface IPersonNameService
    {
        List<PersonNameDto> GetAllPersonNames();
        List<PersonNameDto> GetGeneratedPersonNames(int amount, PersonGenerateParams generatorParams);
        void InsertNewName(PersonNameViewModel name);
        public void InsertNewNames(List<PersonNameDto> newSet);
        void DeleteName(int id);
        void UpdateName(PersonNameViewModel name);
        void DropCollection();
    }
}
