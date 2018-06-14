using DFDSBetting.Models;
using DFDSBetting.Services;
using System.Data.Entity;
using System.Linq;
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
            var matchBegan = (await _context.Matches.Where(m => m.Id == newScoreBetViewModel.MatchId).Select(m => m.Began).FirstOrDefaultAsync());
            if (!ModelState.IsValid || matchBegan)
                return RedirectToAction("Index");

            await _betService.MakeNewScoreBet(newScoreBetViewModel);

            return RedirectToAction("Index", "ScoreBets");
        }

        [HttpPost]
        public async Task<ActionResult> Update(ScoreBetViewModel scoreBetViewModel)
        {
            var matchBegan = (await _context.ScoreBets.Where(b => b.Id == scoreBetViewModel.Id).Select(b => b.Match.Began).FirstOrDefaultAsync());
            if (!ModelState.IsValid || matchBegan)
                return RedirectToAction("Index");

            await _betService.UpdateScoreBet(scoreBetViewModel);

            return RedirectToAction("Index", "ScoreBets");
        }
    }
}