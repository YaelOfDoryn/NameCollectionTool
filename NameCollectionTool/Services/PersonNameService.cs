using AutoMapper;
using LiteDB;
using NameCollectionTool.Dtos;
using NameCollectionTool.Models;
using NameCollectionTool.Services.Interfaces;

namespace NameCollectionTool.Services
{
    public class PersonNameService : IPersonNameService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public PersonNameService(IConfiguration iConfig, IMapper mapper)
        {
            _configuration = iConfig;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all the Person names from the database.
        /// </summary>
        /// <returns>
        /// A collection of PersonNameDtos.
        /// </returns>
        public List<PersonNameDto> GetAllPersonNames()
        {
            using (var db = new LiteDatabase(_configuration["ConnectionStrings:NamesDB"]))
            {
                return db.GetCollection<PersonNameDto>(_configuration["CollectionNames:PersonNames"]).Query().ToList();
            }
        }

        /// <summary>
        /// Inserts a new Person name into the database.
        /// </summary>
        public void InsertNewName(PersonNameViewModel name)
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
                    db.GetCollection<PersonNameDto>(_configuration["CollectionNames:PersonNames"]).Insert(_mapper.Map<PersonNameDto>(name));
                }
            }
        }

        /// <summary>
        /// Removes an existing Person name from the database.
        /// </summary>
        public void DeleteName(int id)
        {
            using (var db = new LiteDatabase(_configuration["ConnectionStrings:NamesDB"]))
            {
                db.GetCollection<PersonNameDto>(_configuration["CollectionNames:PersonNames"]).Delete(id);
            }
        }

        /// <summary>
        /// Updates an existing Person name from the database.
        /// </summary>
        public void UpdateName(PersonNameViewModel name)
        {
            throw new NotImplementedException();
        }
    }
}
