using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zEVRental.Services.CuongCLA
{
    public interface IServiceProviders
    {
        SystemUserAccountService _systemUserAccountService { get; }
        BookingCuongClaService _bookingCuongClaService { get; }

        IPaymentCuongClaService _IpaymentCuongClaService { get; } 
    }

    public class ServiceProviders : IServiceProviders
    {
        private SystemUserAccountService? _SystemUserAccountService;
        private BookingCuongClaService? _BookingCuongClaService;
        private IPaymentCuongClaService? _IpaymentCuongClaService;


        public SystemUserAccountService _systemUserAccountService
        {
            get { return _SystemUserAccountService ?? new SystemUserAccountService(); }
        }
        public BookingCuongClaService _bookingCuongClaService
        {
            get { return _BookingCuongClaService ?? new BookingCuongClaService(); }
        }

        IPaymentCuongClaService IServiceProviders._IpaymentCuongClaService
        {
            get { return _IpaymentCuongClaService ?? new PaymentCuongClaService(); }
        }
    }
}
