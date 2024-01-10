using Application.Interface;
using Application.Interface.MainModule.Master;
using Application.Interface.SecurityModule.Master;
using Application.Repository;
using Application.Repository.MainModule.Master;
using Application.Repository.SecurityModule.Master;
using Domain.Entities.MainModule.Master;
using Domain.Entities.ReservationModule;
using Domain.Entities.SecurityModule.Master;
using Domain.Sales;
using Persistence;
using System;

namespace Application
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HUB_Context _context;
        private readonly IUserService _userService;
        public IBaseRepository<Group> Groups { get; private set; }
        public IBaseRepository<WeekDay> WeekDay { get; private set; }
        public IBaseRepository<Company> Company { get; set; }
        public IBaseRepository<Branch> Branch { get; set; }
        public IBaseRepository<M_850DocType> M850DocType { get; set; }
        public ICountry Country { get; private set; }
        public IUser Users { get; private set; }
        public IPrograms Programs { get; private set; }
        public ICustomer Customer { get; private set; }
        /////New 2024
        public IBaseRepository<OrderH> OrderH { get; set; }
        public IBaseRepository<dynamic> SalesMaster { get; set; }
        /////
        public UnitOfWork(HUB_Context context, IUserService userService)
        {
            _context = context;
            _userService = userService;
            Groups = new BaseRepository<Group>(_context, _userService);
            Country = new CountryRepository(_context, _userService);
            WeekDay = new BaseRepository<WeekDay>(_context, _userService);
            Users = new UserRepository(_context, userService);
            Customer = new CustomerRepo(_context, userService);
            Programs = new ProgramsRepository(_context, _userService);
            Company = new BaseRepository<Company>(_context, _userService);
            Branch = new BaseRepository<Branch>(_context, _userService);
            M850DocType = new BaseRepository<M_850DocType>(_context, _userService);
            /////New 2024
           OrderH= new BaseRepository<OrderH>(_context, _userService);
            SalesMaster = new BaseRepository<dynamic>(_context, _userService);
        }
        public async Task<int> Complete()
        {
         
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
