using Microsoft.AspNetCore.Mvc;
using NeZaboravi.Data;
using NeZaboravi.Interfaces;
using NeZaboravi.Models;
using System.Diagnostics;

namespace NeZaboravi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKorisnikService _korisnikService;
        private readonly ILogService _logService;
        private readonly IStatisticsService _statisticsService;
        private readonly IUserContextService _userContextService;

        public HomeController(
            ILogger<HomeController> logger,
            IKorisnikService korisnikService,
            ILogService logService,
            IStatisticsService statisticsService,
            IUserContextService userContextService)
        {
            _logger = logger;
            _korisnikService = korisnikService;
            _logService = logService;
            _statisticsService = statisticsService;
            _userContextService = userContextService;
        }

        public async Task<IActionResult> Index()
        {
            await _logService.LogActivityAsync("Entered website");

            if (_userContextService.IsUserAuthenticated())
            {
                var username = _userContextService.GetCurrentUsername();
                var existingUser = await _korisnikService.GetKorisnikByUsernameAsync(username);

                if (existingUser == null)
                {
                    return RedirectToAction("Create", "Korisnik");
                }

                return RedirectToAction("IndexLoggedIn");
            }

            await SetStatisticsViewBag();
            return View();
        }

        public IActionResult ArtiklIndex()
        {
            return RedirectToAction("Index", "Artikl");
        }

        public IActionResult ArtiklCreate()
        {
            return RedirectToAction("Create", "Artikl");
        }

        public async Task<IActionResult> IndexLoggedIn()
        {
            await SetStatisticsViewBag();
            return RedirectToAction("Index", "Artikl");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task SetStatisticsViewBag()
        {
            var logsCount = await _logService.GetLogsCountAsync();
            var registeredUsers = await _statisticsService.GetRegisteredUsersCountAsync();
            var registeredArtikls = await _statisticsService.GetArtiklsCountAsync();

            ViewBag.RegistriranihKorisnika = _statisticsService.CalculateDisplayUsersCount(logsCount, registeredUsers);
            ViewBag.NapravljenihZapisa = _statisticsService.CalculateDisplayRecordsCount(logsCount, registeredArtikls);
        }
    }
}