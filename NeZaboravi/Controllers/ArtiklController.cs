using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using NeZaboravi.Data;
using NeZaboravi.Interfaces;
using NeZaboravi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeZaboravi.Controllers
{
    [Authorize]
    public class ArtiklController : Controller
    {
        private readonly IArtiklService _artiklService;
        private readonly IUserContextService _userContextService;

        public ArtiklController(IArtiklService artiklService, IUserContextService userContextService)
        {
            _artiklService = artiklService;
            _userContextService = userContextService;
        }

        public async Task<IActionResult> Index()
        {
            var username = _userContextService.GetCurrentUsername();
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            var artikls = await _artiklService.GetUserArtiklsAsync(username);
            return View(artikls);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var artikl = await _artiklService.GetArtiklByIdAsync(id.Value);
            if (artikl == null)
            {
                return NotFound();
            }

            return View(artikl);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ime,Ducan")] Artikl artikl)
        {
            if (!ModelState.IsValid)
            {
                return View(artikl);
            }

            var username = _userContextService.GetCurrentUsername();
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            await _artiklService.CreateArtiklAsync(artikl, username);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var artikl = await _artiklService.GetArtiklByIdAsync(id.Value);
            if (artikl == null)
            {
                return NotFound();
            }

            return View(artikl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Ducan")] Artikl artikl)
        {
            if (id != artikl.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(artikl);
            }

            var success = await _artiklService.UpdateArtiklAsync(artikl);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var success = await _artiklService.DeleteArtiklAsync(id.Value);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
