using MitraisCodingTest.Core.Exceptions;
using MitraisCodingTest.Core.Models;
using MitraisCodingTest.Core.Repositories.Interface;
using MitraisCodingTest.Core.Services.Interface;
using MitraisCodingTest.Core.Services.Request;
using PhoneNumbers;
using System;

namespace MitraisCodingTest.Core.Services
{
    public class UserService : IUserService
    {
        private const string ZERO = "0";

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(UserRequest request)
        {
            ValidateToAdd(request);

            var user = new User
            {
                Email = request.Email,
                Firstname = request.Firstname,
                Gender = request.Gender,
                Lastname = request.Lastname,
                MobileNumber = GetNationalNumber(request.MobileNumber),
                DateOfBirth = GetDate(request)
            };

            _userRepository.Add(user);
        }

        private void ValidateToAdd(UserRequest request)
        {
            if (!IsValidMobilePhone(request.MobileNumber)) throw new InvalidValueException("Invalid mobile number");
            if (_userRepository.IsExistByMobileNumber(GetNationalNumber(request.MobileNumber))) throw new ItemExistException("Mobile number should be unique");
            if (!IsValidDateRequest(request)) throw new InvalidValueException("Invalid Date");
            if (_userRepository.IsExistByEmail(request.Email)) throw new ItemExistException("Email should be unique");
        }

        private bool IsValidDateRequest(UserRequest request)
        {
            if (request.Year == ZERO && request.Month == ZERO && request.Date == ZERO)
            {
                return true;
            }

            if (request.Year == ZERO || request.Month == ZERO || request.Date == ZERO)
            {
                return false;
            }

            try
            {
                var dateText = $"{request.Month}/{request.Date}/{request.Year}";
                Convert.ToDateTime(dateText);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidMobilePhone(string mobileNumber)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var phoneNumber = phoneNumberUtil.Parse(mobileNumber, "ID");
            return phoneNumberUtil.IsPossibleNumberForType(phoneNumber, PhoneNumberType.MOBILE);
        }

        private string GetNationalNumber(string mobileNumber)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var phoneNumber = phoneNumberUtil.Parse(mobileNumber, "ID");
            return phoneNumber.NationalNumber.ToString();
        }

        private DateTime GetDate(UserRequest request)
        {
            var dateText = $"{request.Month}/{request.Date}/{request.Year}";
            return Convert.ToDateTime(dateText);
        }
    }
}
