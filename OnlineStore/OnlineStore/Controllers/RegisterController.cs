using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OnlineStore.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineStore.Controllers
{
    public class RegisterController : Controller
    {
        private OnlineStoreService _onlineStoreService;

        public IActionResult Index()
        {
            var registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(RegisterViewModel registerViewModel)

        {
            if (ModelState.IsValid)
            {

                _onlineStoreService.RegisterCustomer(registerViewModel);
                return View("RegistrationConfirmation");
            }

            return View(registerViewModel);
        }
    }
}
