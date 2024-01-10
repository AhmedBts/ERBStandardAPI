
using Application.Interface;
using Application.Interface.MainModule.Master;
using Application.Interface.SecurityModule.Master;
using Domain.Entities.MainModule.Master;
using Domain.Entities.ReservationModule;
using Domain.Entities.SecurityModule.Master;
using Domain.Sales;


namespace Application
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Group> Groups { get; }
        IBaseRepository<WeekDay> WeekDay { get; }
        IBaseRepository<Company> Company { get; }
        IBaseRepository<Branch> Branch { get; }

        IBaseRepository<M_850DocType> M850DocType { get; }
        ////New 2024
        IBaseRepository<OrderH> OrderH { get; }
        IBaseRepository<dynamic> SalesMaster { get; }
        ////
        ICountry Country { get; }
        IUser Users { get; }
        ICustomer Customer { get; }

        IPrograms Programs { get; }
        Task<int> Complete();
    }
}