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
            db = new LiteDatabase(_configuration["ConnectionStrings:NamesDB"]);
        }

        /// <summary>
        /// Gets all the Person names from the database.
        /// </summary>
        /// <returns>
        /// A collection of PersonNameDtos.
        /// </returns>
        public List<PersonNameDto> GetAllPersonNames()
        {
            return db.GetCollection<PersonNameDto>("PersonNames").Query().ToList();
        }

        /// <summary>
        /// Inserts a new Person name into the database.
        /// </summary>
        public void InsertNewName(PersonNameDto name)
        {
            db.GetCollection<PersonNameDto>("PersonNames").Insert(name);
        }

        /// <summary>
        /// Removes an existing Person name from the database.
        /// </summary>
        public void DeleteName(int id)
        {
            db.GetCollection<PersonNameDto>("PersonNames").Delete(id);
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
