using NameCollectionTool.Dtos;
using NameCollectionTool.Models;

namespace NameCollectionTool.Services.Interfaces
{
    public interface IPlaceNamesService
    {
        List<PlaceNameDto> GetAllNames();
        void InsertNewName(PlaceNameViewModel name);
        public void InsertNewNames(List<PlaceNameDto> newSet);
        void DeleteName(int id);
        void UpdateName(PlaceNameViewModel name);
    }
}
