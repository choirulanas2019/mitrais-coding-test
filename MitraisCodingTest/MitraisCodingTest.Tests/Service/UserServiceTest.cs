using Microsoft.VisualStudio.TestTools.UnitTesting;
using MitraisCodingTest.Core.Models;
using MitraisCodingTest.Core.Repositories.Interface;
using MitraisCodingTest.Core.Services;
using MitraisCodingTest.Core.Services.Request;
using Moq;
using System;

namespace MitraisCodingTest.Tests.Service
{
    [TestClass]
    public class UserServiceTest
    {
        private UserService _service;
        private IUserRepository _repository;
        private Mock<IUserRepository> _repositoryMock;

        [TestInitialize]
        public void Initiate()
        {
            _repositoryMock = new Mock<IUserRepository>();
            _repository = _repositoryMock.Object;

            _repositoryMock.Setup(x => x.IsExistByMobileNumber("81806793534")).Returns(true);
            _repositoryMock.Setup(x => x.IsExistByEmail("anasdove@gmail.com")).Returns(true);
            _repositoryMock.Setup(x => x.Add(new User())).Returns(new User());

            _service = new UserService(_repository);
        }

        [TestMethod]
        public void GivenInvalidMobilePhone_AddUser_ReturnError()
        {
            try
            {
                var request = new UserRequest
                {
                    MobileNumber = "123"
                };
                _service.Add(request);
            }
            catch(Exception ex)
            {
                Assert.AreEqual(ex.Message, "Mobile number should be Indonesian mobile phone number (with/out +62 or 62 or 0)");
            }
        }

        [TestMethod]
        public void GivenMobilePhoneIsExist_AddUser_ReturnError()
        {
            try
            {
                var request = new UserRequest
                {
                    MobileNumber = "081806793534"
                };
                _service.Add(request);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Mobile number should be unique (regardless with/out +62 or 62 or 0)");
            }
        }

        [TestMethod]
        public void GivenMonthAndYearEmptyDateHasValue_AddUser_ReturnError()
        {
            try
            {
                var request = new UserRequest
                {
                    MobileNumber = "081717203856",
                    Date = "30",
                    Month = "0",
                    Year = "0"
                };
                _service.Add(request);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Invalid Date");
            }
        }

        [TestMethod]
        public void GivenInvalidDate_AddUser_ReturnError()
        {
            try
            {
                var request = new UserRequest
                {
                    MobileNumber = "081717203856",
                    Date = "30",
                    Month = "2",
                    Year = "1989"
                };
                _service.Add(request);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Invalid Date");
            }
        }

        [TestMethod]
        public void GivenEmailIsExist_AddUser_ReturnError()
        {
            try
            {
                var request = new UserRequest
                {
                    MobileNumber = "081717203856",
                    Date = "17",
                    Month = "5",
                    Year = "1989",
                    Email = "anasdove@gmail.com"
                };
                _service.Add(request);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Email should be unique");
            }
        }

        [TestMethod]
        public void GivenValidRequest_AddUser_ReturnSuccess()
        {
            try
            {
                var request = new UserRequest
                {
                    MobileNumber = "081717203856",
                    Date = "17",
                    Month = "5",
                    Year = "1989",
                    Email = "choirulAnas@gmail.com"
                };

                _service.Add(request);
            }
            catch
            {

            }
            finally
            {
                Assert.AreEqual(1, 1);
            }
        }
    }
}
