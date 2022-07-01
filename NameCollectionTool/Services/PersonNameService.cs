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
        /// Inserts a range of new Person names into the database.
        /// </summary>
        public void InsertNewNames(List<PersonNameDto> newSet)
        {
            // TODO: Check if there are no doubles in the set that is being added


           
            using (var db = new LiteDatabase(_configuration["ConnectionStrings:NamesDB"]))
            {
                List<PersonNameDto> fullSet = db.GetCollection<PersonNameDto>(_configuration["CollectionNames:PersonNames"]).Query().ToList();
                fullSet.AddRange(newSet); // Add new set to the list

                // First create a list with all the distinct items.
                // Then remove these from the set, leaving only the doubles.
                fullSet.RemoveAll(x => fullSet.GroupBy(c => new
                {
                    c.FirstName,
                    c.LastName
                }).Select(y => y.First()).ToList().Contains(x));

                // Remove the doubles from the new set
                newSet.RemoveAll(x => fullSet.Contains(x));

                // Add the distinct objects from the new set to the database
                db.GetCollection<PersonNameDto>(_configuration["CollectionNames:PersonNames"]).InsertBulk((IEnumerable<PersonNameDto>)newSet);
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
