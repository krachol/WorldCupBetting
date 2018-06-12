using DFDSBetting.Models;
using DFDSBetting.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DFDSBetting.Controllers
{
    [Authorize]
    public class ScoreBetsController : Controller
    {
        private ApplicationDbContext _context;
        private BetService _betService;

        public ScoreBetsController()
        {
            _context = new ApplicationDbContext();
            _betService = new BetService(_context);
        }

        // GET: Bet
        public async Task<ActionResult> Index()
        {
            var viewModel = await _betService.GetListOfMatchesWithBetsAsync();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(NewScoreBetViewModel newScoreBetViewModel)
        {
            if (!ModelState.IsValid)
                return View("Index");

            await _betService.MakeNewScoreBet(newScoreBetViewModel);

            return RedirectToAction("Index", "ScoreBets");
        }

        [HttpPost]
        public async Task<ActionResult> Update(ScoreBetViewModel scoreBetViewModel)
        {
            if (!ModelState.IsValid)
                return View("Index", await _betService.GetListOfMatchesWithBetsAsync());

            await _betService.UpdateScoreBet(scoreBetViewModel);

            return RedirectToAction("Index", "ScoreBets");
        }
    }
}