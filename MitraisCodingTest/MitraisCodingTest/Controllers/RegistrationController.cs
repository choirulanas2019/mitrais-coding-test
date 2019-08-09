using MitraisCodingTest.Core.Exceptions;
using MitraisCodingTest.Core.Services.Interface;
using MitraisCodingTest.Core.Services.Request;
using MitraisCodingTest.Models;
using System;
using System.Web.Mvc;

namespace MitraisCodingTest.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUserService _userService;

        public RegistrationController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Create()
        {
            var model = new RegistrationModel
            {
                Gender = "Male",
                IsRegistrationSucceed = false
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(RegistrationModel model)
        {
            try
            {
                var request = new UserRequest
                {
                    Date = model.Date,
                    Email = model.Email,
                    Firstname = model.Firstname,
                    Gender = model.Gender,
                    Lastname = model.Lastname,
                    MobileNumber = model.MobileNumber,
                    Month = model.Month,
                    Year = model.Year
                };

                _userService.Add(request);

                model.IsRegistrationSucceed = true;

                return View(model);
            }
            catch (InvalidValueException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                model.IsRegistrationSucceed = false;
                return View(model);
            }
            catch (ItemExistException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                model.IsRegistrationSucceed = false;
                return View(model);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                model.IsRegistrationSucceed = false;
                return View(model);
            }
        }
    }
}