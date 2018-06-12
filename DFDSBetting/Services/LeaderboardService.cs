using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DFDSBetting.Models;

namespace DFDSBetting.Services
{
    internal class LeaderboardService
    {
        private ApplicationDbContext _context;

        public LeaderboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        internal async Task<List<UsersWithPointsViewModel>> GetUsersWithPointsAsync()
        {
            return await _context.Users.Select(u => new UsersWithPointsViewModel
            {
                UserName = u.UserName,
                Points = 0
            }).ToListAsync();
        }
    }
}