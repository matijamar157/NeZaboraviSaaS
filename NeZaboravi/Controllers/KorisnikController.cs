using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class KorisnikController : Controller
    {
        private readonly IKorisnikService _korisnikService;
        private readonly IUserContextService _userContextService;

        public KorisnikController(IKorisnikService korisnikService, IUserContextService userContextService)
        {
            _korisnikService = korisnikService;
            _userContextService = userContextService;
        }

        public async Task<IActionResult> Index()
        {
            var korisnici = await _korisnikService.GetAllKorisniciAsync();
            return View(korisnici);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var korisnik = await _korisnikService.GetKorisnikByIdAsync(id.Value);
            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ime")] Korisnik korisnik)
        {
            if (!ModelState.IsValid)
            {
                return View(korisnik);
            }

            var username = _userContextService.GetCurrentUsername();
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            await _korisnikService.CreateKorisnikAsync(korisnik, username);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var korisnik = await _korisnikService.GetKorisnikByIdAsync(id.Value);
            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Username,Username2,Username3,Username4,Username5,Username6,Username7,Username8,Username9,Username10")] Korisnik korisnik)
        {
            if (id != korisnik.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(korisnik);
            }

            var success = await _korisnikService.UpdateKorisnikAsync(korisnik);
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

            var korisnik = await _korisnikService.GetKorisnikByIdAsync(id.Value);
            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _korisnikService.DeleteKorisnikAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
