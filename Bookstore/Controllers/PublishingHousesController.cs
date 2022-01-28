using Bookstore.Data;
using Bookstore.Data.Services;
using Bookstore.Data.Static;
using Bookstore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class PublishingHousesController : Controller
    {
        private readonly IPublishingHousesService _service;

        public PublishingHousesController(IPublishingHousesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allPublishingHouses = await _service.GetAllAsync();
            return View(allPublishingHouses);
        }


        //Get: PublishingHouses/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("LogoURL,Name,Description")]PublishingHouse publishingHouse)
        {
            if (!ModelState.IsValid) return View(publishingHouse);
            await _service.AddAsync(publishingHouse);
            return RedirectToAction(nameof(Index));
        }

        //Get: PublishingHouses/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var publishingHouseDetails = await _service.GetByIdAsync(id);
            if (publishingHouseDetails == null) return View("NotFound");
            return View(publishingHouseDetails);
        }

        //Get: PublishingHouses/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var publishingHouseDetails = await _service.GetByIdAsync(id);
            if (publishingHouseDetails == null) return View("NotFound");
            return View(publishingHouseDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LogoURL,Name,Description")] PublishingHouse publishingHouse)
        {
            if (!ModelState.IsValid) return View(publishingHouse);
            await _service.UpdateAsync(id, publishingHouse);
            return RedirectToAction(nameof(Index));
        }

        //Get: PublishingHouses/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var publishingHouseDetails = await _service.GetByIdAsync(id);
            if (publishingHouseDetails == null) return View("NotFound");
            return View(publishingHouseDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var publishingHouseDetails = await _service.GetByIdAsync(id);
            if (publishingHouseDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
