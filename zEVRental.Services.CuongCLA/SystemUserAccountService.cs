using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zEVRental.Repositories.CuongCLA;
using zEVRental.Repositories.CuongCLA.Models;

namespace zEVRental.Services.CuongCLA
{
    public class SystemUserAccountService
    {
        private readonly IUnitOfWork _unitOfWork    ;
        public SystemUserAccountService() => _unitOfWork ??= new UnitOfWork();
        public async Task<SystemUserAccount> GetUserAccount(string username, string password)
        {
            try
            {
                return await _unitOfWork.SystemUserAccountRepository.GetUserAccount(username, password);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message +"\n"+ex.StackTrace);
            }
            return null;

        }

        public async Task<List<SystemUserAccount>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.SystemUserAccountRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
            }
            return new List<SystemUserAccount>();
        }

        public async Task<SystemUserAccount> GetByIdAsync(int value)
        {
            try
            {
                return await _unitOfWork.SystemUserAccountRepository.GetByIdAsync(value);
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}
