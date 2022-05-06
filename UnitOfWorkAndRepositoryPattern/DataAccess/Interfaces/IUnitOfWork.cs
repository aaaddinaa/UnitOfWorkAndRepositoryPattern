using System;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository People { get; }
        IAddressRepository Addresses { get; }
        IEmailRepository Emails { get; }
        int Save();
    }
}
