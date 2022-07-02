using AutoMapper;
using LiteDB;
using NameCollectionTool.Dtos;
using NameCollectionTool.Models;
using NameCollectionTool.Services.Interfaces;

namespace NameCollectionTool.Services
{
    public class CollectionsService : ICollectionsService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public CollectionsService(IConfiguration iConfig, IMapper mapper)
        {
            _configuration = iConfig;
            _mapper = mapper;
        }

        public CollectionsStatistics GetCollectionStats()
        {
            CollectionsStatistics stats = new CollectionsStatistics();

            using (var db = new LiteDatabase(_configuration["ConnectionStrings:NamesDB"]))
            {
                stats.PersonNamesCount = db.GetCollection<PersonNameDto>(_configuration["CollectionNames:PersonNames"]).Query().ToList().Count();
                stats.PlaceNamesCount = db.GetCollection<PlaceNameDto>(_configuration["CollectionNames:PlaceNames"]).Query().ToList().Count();
            }

            return stats;
        }
    }
}
