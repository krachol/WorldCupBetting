using DFDSBetting.Models;
using DFDSBetting.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DFDSBetting.Controllers
{
    [Authorize]
    public class WinnerBetsController : Controller
    {
        ApplicationDbContext _context;
        BetService _betService;

        public WinnerBetsController()
        {
            _context = new ApplicationDbContext();
            _betService = new BetService(_context);
        }

        // GET: WinnerBerts
        public async Task<ActionResult> Index()
        {
            var viewModel = await _betService.GetListOfTeamsWithBetsAsync();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> MakeBet(NewWinnerBetViewModel newBet )
        {
            await _betService.MakeNewWinnerBet(newBet);

            return RedirectToAction("Index");
        }
    }
}