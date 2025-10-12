using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zEVRental.Repositories.CuongCLA.Models;

namespace zEVRental.Repositories.CuongCLA
{
    public interface IUnitOfWork
    {
        SystemUserAccountRepository SystemUserAccountRepository { get; }
        BookingCuongClaRepository BookingCuongClaRepository { get; }

        PaymentCuongClaRepository PaymentCuongClaRepository { get; }

        int SaveChangeWithTransaction();

        Task<int> SaveChangeWithTransactionAsync();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FA25_PRN222_SE1834_G3_EVRentalContext _context;
        private SystemUserAccountRepository _systemUserAccountRepository;
        private BookingCuongClaRepository _bookingCuongClaRepository;
        private PaymentCuongClaRepository _paymentCuongClaRepository;
        public UnitOfWork() => _context = new FA25_PRN222_SE1834_G3_EVRentalContext();

        public SystemUserAccountRepository SystemUserAccountRepository
        {
            get
            {
                return _systemUserAccountRepository ??= new SystemUserAccountRepository(_context);
            }
        }


        public BookingCuongClaRepository BookingCuongClaRepository
        {
            get
            {
                return _bookingCuongClaRepository ??= new BookingCuongClaRepository(_context);
            }
        }


        public PaymentCuongClaRepository PaymentCuongClaRepository
        {
            get
            {
                return _paymentCuongClaRepository ??= new PaymentCuongClaRepository(_context);
            }
        }


        public int SaveChangeWithTransaction()
        {
            int result = 0;

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {

                    result = _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    result = 0;
                    dbContextTransaction.Rollback();
                }
            }
            return result;
        }


        public async Task<int> SaveChangeWithTransactionAsync()
        {
            int result = 0;
            using (var dbContextTransaction = _context.Database.BeginTransactionAsync())
            {
                try
                {
                    result = await _context.SaveChangesAsync();
                    dbContextTransaction.Result.CommitAsync();
                }
                catch (Exception)
                {
                    result = 0;
                    dbContextTransaction.Result.RollbackAsync();
                }
            }
            return result;
        }

    }
}
