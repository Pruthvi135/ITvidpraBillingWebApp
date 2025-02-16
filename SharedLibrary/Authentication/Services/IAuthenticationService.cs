using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Authentication.Services
{
    public interface IAuthenticationService
    {
        Task<bool> SendOtpAsync(string mobileNo);
        Task<bool> VerifyOtpAsync(string mobileNo, string otp);
    }
}
