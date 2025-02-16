using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using itvidpradotnetcoreadvanced.Models; // Use models from the existing project
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Authentication.Interfaces;
using SharedLibrary.Authentication.Services;

namespace SharedLibrary.Authentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserDbContext _context;

        // In-memory storage for OTPs. In production, use a cache (e.g., Redis).
        private static readonly ConcurrentDictionary<string, string> _otpStore = new ConcurrentDictionary<string, string>();

        public AuthenticationService(IUserDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SendOtpAsync(string mobileNo)
        {
            var user = await _context.Users
                                     .Where(u => u.MobileNo == mobileNo)
                                     .FirstOrDefaultAsync();
            if (user != null)
            {
                var otp = new Random().Next(100000, 999999).ToString();
                _otpStore[mobileNo] = otp;
                Console.WriteLine($"OTP Sent to {mobileNo}: {otp}");
                return true;
            }
            return false;
        }

        public async Task<bool> VerifyOtpAsync(string mobileNo, string otp)
        {
            if (_otpStore.TryGetValue(mobileNo, out string storedOtp))
            {
                if (storedOtp == otp)
                {
                    _otpStore.TryRemove(mobileNo, out _);
                    Console.WriteLine($"OTP Verified for {mobileNo}");
                    return true;
                }
            }
            Console.WriteLine($"Invalid OTP for {mobileNo}");
            return false;
        }
    }
}
