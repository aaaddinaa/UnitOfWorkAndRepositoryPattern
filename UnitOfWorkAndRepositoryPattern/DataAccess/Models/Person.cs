using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Person : BaseEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }

        public List<Email> Emails { get; set; }
    }
}
