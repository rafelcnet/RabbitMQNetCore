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
    public class AdminController : Controller
    {
        private OnlineStoreService _onlineStoreService;

        public AdminController()
        {
            _onlineStoreService = new OnlineStoreService();
        }

        public IActionResult Index()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            adminViewModel.RegisteredCustomers = _onlineStoreService.GetRegisteredCustomers();
            return View(adminViewModel);
        }
    }
}
