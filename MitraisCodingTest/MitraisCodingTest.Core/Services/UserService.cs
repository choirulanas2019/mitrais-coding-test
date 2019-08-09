using MitraisCodingTest.Core.Exceptions;
using MitraisCodingTest.Core.Models;
using MitraisCodingTest.Core.Repositories.Interface;
using MitraisCodingTest.Core.Services.Interface;
using MitraisCodingTest.Core.Services.Request;
using PhoneNumbers;

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
            };

            _userRepository.Add(user);
        }

        private void ValidateToAdd(UserRequest request)
        {
            if (!IsValidDateOfBirth(request)) throw new InvalidValueException("Invalid Date");
            if (_userRepository.IsExistByEmail(request.Email)) throw new ItemExistException("Email should be unique");
            if (!IsValidMobilePhone(request.MobileNumber)) throw new InvalidValueException("Invalid mobile number");
            if (_userRepository.IsExistByMobileNumber(GetNationalNumber(request.MobileNumber))) throw new ItemExistException("Mobile number should be unique");
        }

        private bool IsValidDateOfBirth(UserRequest request)
        {
            if (request.Year == ZERO && request.Month == ZERO && request.Date == ZERO)
            {
                return true;
            }

            return !(request.Year == ZERO || request.Month == ZERO || request.Date == ZERO);
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
    }
}
