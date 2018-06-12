using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using DFDSBetting.Models;

namespace DFDSBetting.Services
{
    internal class UserService
    {
        ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> GetLoggedInUserAsync()
        {
            return await _context.Users.FirstAsync(u => u.UserName == HttpContext.Current.User.Identity.Name);
        }
    }
}