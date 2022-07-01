using LiteDB;
using NameCollectionTool.Dtos;
using NameCollectionTool.Services.Interfaces;

namespace NameCollectionTool.Services
{
    public class PersonNameService : IPersonNameService
    {
        private LiteDatabase db;
        private readonly IConfiguration _configuration;

        public PersonNameService(IConfiguration iConfig)
        {
            _configuration = iConfig;
        }

        /// <summary>
        /// Gets all the Person names from the database.
        /// </summary>
        /// <returns>
        /// A collection of PersonNameDtos.
        /// </returns>
        public List<PersonNameDto> GetAllPersonNames()
        {
            using (db = new LiteDatabase(_configuration["ConnectionStrings:NamesDB"]))
            {
                return db.GetCollection<PersonNameDto>(_configuration["CollectionNames:PersonNames"]).Query().ToList();
            }
        }

        /// <summary>
        /// Inserts a new Person name into the database.
        /// </summary>
        public void InsertNewName(PersonNameDto name)
        {
            using (db = new LiteDatabase(_configuration["ConnectionStrings:NamesDB"]))
            {
                db.GetCollection<PersonNameDto>(_configuration["CollectionNames:PersonNames"]).Insert(name);
            }
        }

        /// <summary>
        /// Removes an existing Person name from the database.
        /// </summary>
        public void DeleteName(int id)
        {
            using (db = new LiteDatabase(_configuration["ConnectionStrings:NamesDB"]))
            {
                db.GetCollection<PersonNameDto>(_configuration["CollectionNames:PersonNames"]).Delete(id);
            }
        }

        /// <summary>
        /// Updates an existing Person name from the database.
        /// </summary>
        public void UpdateName(PersonNameDto name)
        {
            throw new NotImplementedException();
        }
    }
}
