using AutoMapper;
using LiteDB;
using NameCollectionTool.Dtos;
using NameCollectionTool.Models;
using NameCollectionTool.Services.Interfaces;

namespace NameCollectionTool.Services
{
    public class PlaceNamesService : IPlaceNamesService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public PlaceNamesService(IConfiguration iConfig, IMapper mapper)
        {
            _configuration = iConfig;
            _mapper = mapper;
        }

        public List<PlaceNameDto> GetAllNames()
        {
            using (var db = new LiteDatabase(_configuration["ConnectionStrings:NamesDB"]))
            {
                return db.GetCollection<PlaceNameDto>(_configuration["CollectionNames:PlaceNames"]).Query().ToList();
            }
        }

        public void DeleteName(int id)
        {
            using (var db = new LiteDatabase(_configuration["ConnectionStrings:NamesDB"]))
            {
                db.GetCollection<PlaceNameDto>(_configuration["CollectionNames:PlaceNames"]).Delete(id);
            }
        }        

        public void InsertNewName(PlaceNameViewModel name)
        {
            if (name != null)
            {
                if (name.Tags.First() != null)
                {
                    // Divide up the tags, trim them and add them to the tag list
                    name.Tags = name.Tags.First().Split(',').Select(x => x.Trim()).ToList();
                }

                using (var db = new LiteDatabase(_configuration["ConnectionStrings:NamesDB"]))
                {
                    db.GetCollection<PlaceNameDto>(_configuration["CollectionNames:PlaceNames"]).Insert(_mapper.Map<PlaceNameDto>(name));
                }
            }
        }

        public void InsertNewNames(List<PlaceNameDto> newSet)
        {
            using (var db = new LiteDatabase(_configuration["ConnectionStrings:NamesDB"]))
            {
                List<PlaceNameDto> fullSet = db.GetCollection<PlaceNameDto>(_configuration["CollectionNames:PlaceNames"]).Query().ToList();
                fullSet.AddRange(newSet); // Add new set to the list

                // First create a list with all the distinct items.
                // Then remove these from the set, leaving only the doubles.
                fullSet.RemoveAll(x => fullSet.GroupBy(c => new
                {
                    c.Name
                }).Select(y => y.First()).ToList().Contains(x));

                // Remove the doubles from the new set
                newSet.RemoveAll(x => fullSet.Contains(x));

                // Add the distinct objects from the new set to the database
                db.GetCollection<PlaceNameDto>(_configuration["CollectionNames:PlaceNames"]).InsertBulk((IEnumerable<PlaceNameDto>)newSet);
            }
        }

        public void UpdateName(PlaceNameViewModel name)
        {
            throw new NotImplementedException();
        }
    }
}
