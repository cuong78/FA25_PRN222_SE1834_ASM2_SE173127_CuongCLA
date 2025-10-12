﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zEVRental.Repositories.CuongCLA;
using zEVRental.Repositories.CuongCLA.Models;

namespace zEVRental.Services.CuongCLA
{
    public class PaymentCuongClaService : IPaymentCuongClaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PaymentCuongClaService() => _unitOfWork??= new UnitOfWork();

        public async Task<int> CreateAsync(PaymentCuongCla paymentCuong)
        {
            try { 
                return await _unitOfWork.PaymentCuongClaRepository.CreateAsync(paymentCuong);
            }
            catch (Exception e) {
                // throw new Exception(ex.Message);
            }
            return 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try {
                var item = await _unitOfWork.PaymentCuongClaRepository.GetByIdAsync(id);
                if (item != null)
                {
                   return await _unitOfWork.PaymentCuongClaRepository.RemoveAsync(item);
                     
                }
            }
            catch (Exception e) {
                // throw new Exception(ex.Message);
                }
                return false;
        }

        public async Task<List<PaymentCuongCla>> GetAllAsync()
        {
            try
            {
                ////Business rules here
                var items = await _unitOfWork.PaymentCuongClaRepository.GetAllAsync();
                return items;
            }
            catch (Exception ex)
            {
               // throw new Exception(ex.Message);
            }
            return new List<PaymentCuongCla>();
        }

        public async Task<PaymentCuongCla> GetByIdAsync(int id)
        {
            try
            {
                var item = await _unitOfWork.PaymentCuongClaRepository.GetByIdAsync(id);
                return item;
            }
            catch (Exception ex)
            {
                // throw new Exception(ex.Message);
            }
            return null;
          }

        public async Task<List<PaymentCuongCla>> SearchAsync(string paymentMethod, decimal? amount, string status)
        {
            try { 
                var items = await _unitOfWork.PaymentCuongClaRepository.SearchAsync(paymentMethod, amount ,  status);
                return items;
            }
            catch (Exception ex) 
            {
                // throw new Exception(ex.Message);
            }
            return new List<PaymentCuongCla>();
        }

        public async Task<int> UpdateAsync(PaymentCuongCla paymentCuong)
        {
            try { 
                return await _unitOfWork.PaymentCuongClaRepository.UpdateAsync(paymentCuong);
            }
            catch (Exception e)
            {
                // throw new Exception(ex.Message);
            }

            return 0;
        }
    }
}
