using MitraisCodingTest.Models;
using System.Web.Mvc;

namespace MitraisCodingTest.Controllers
{
    public class RegistrationController : Controller
    {
        public ActionResult Create()
        {
            var registrationModel = new RegistrationModel();
            registrationModel.Gender = "Male";

            return View(registrationModel);
        }

        [HttpPost]
        public ActionResult Create(RegistrationModel model)
        {
            if (!IsValidDateOfBirth(model))
            {
                ModelState.AddModelError(string.Empty, "Date of Birth is invalid");
            }

            return View(model);
        }

        private bool IsValidDateOfBirth(RegistrationModel model)
        {
            if (model.Year == "0" && model.Month == "0" && model.Date == "0")
            {
                return true;
            }

            return !(model.Year == "0" || model.Month == "0" || model.Date == "0");
        }
    }
}