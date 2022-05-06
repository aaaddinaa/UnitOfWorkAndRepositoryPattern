using DataAccess.Interfaces;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {

        public PersonRepository(MyContext context) : base(context)
        {

        }

        public IEnumerable<Person> GetFistTwoPeople()
        {
            return _context.People.Take(2).ToList();
        }
    }
}
