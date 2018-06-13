using DFDSBetting.Models;
using DFDSBetting.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DFDSBetting.Controllers
{
    [Authorize]
    public class LeaderboardController : Controller
    {
        private ApplicationDbContext _context;
        private LeaderboardService _leaderboardService;

        public LeaderboardController()
        {
            _context = new ApplicationDbContext();
            _leaderboardService = new LeaderboardService(_context);
        }

        // GET: Leaderboard
        public async Task<ActionResult> Index()
        {
            List<UsersWithPointsViewModel> viewModel = await _leaderboardService.GetUsersWithPointsAsync();

            return View(viewModel);
        }
    }
}