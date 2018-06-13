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
        private PointsService _pointsService;

        public LeaderboardService(ApplicationDbContext context)
        {
            _context = context;
            _pointsService = new PointsService(context);
        }

        internal async Task<List<UsersWithPointsViewModel>> GetUsersWithPointsAsync()
        {
            var users = await _context.Users.ToListAsync();
            List<UsersWithPointsViewModel> list = new List<UsersWithPointsViewModel>();
            foreach (var user in users)
            {
                list.Add(new UsersWithPointsViewModel
                {
                    UserName = user.UserName,
                    Points = await _pointsService.GetPointsForUserAsync(user)
                });
            }
            return list.OrderByDescending(u => u.Points).ToList();
        }
    }
}