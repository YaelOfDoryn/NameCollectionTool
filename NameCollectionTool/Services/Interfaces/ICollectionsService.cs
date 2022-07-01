using NameCollectionTool.Models;

namespace NameCollectionTool.Services.Interfaces
{
    public interface ICollectionsService
    {
        CollectionsStatistics GetCollectionStats();
    }
}
