using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;
        public UnitOfWork(MyContext context)
        {
            _context = context;
            People = new PersonRepository(_context);
            Addresses = new AddressRepository(_context);
            Emails = new EmailRepository(_context);
        }

        public IPersonRepository People { get; private set; }
        public IAddressRepository Addresses { get; private set; }
        public IEmailRepository Emails { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
