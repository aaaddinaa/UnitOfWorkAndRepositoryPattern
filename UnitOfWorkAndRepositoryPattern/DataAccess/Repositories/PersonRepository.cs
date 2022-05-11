using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
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

        public override IEnumerable<Person> GetAll()
        {
            return _context.People.Include(a => a.Address)
                                  .Include(e => e.Emails).ToList();
        }

        


    }
}
