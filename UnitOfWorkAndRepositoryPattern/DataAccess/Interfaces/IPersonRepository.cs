using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> GetFistTwoPeople();
    }
}
