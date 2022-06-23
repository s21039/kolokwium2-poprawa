using kolokwium2_poprawa.Models;
using kolokwium2_poprawa.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2_poprawa.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _context;

        public DbService(MainDbContext context)
        {
            _context = context;
        }

        public async Task<Membership> AddMember(PostMembership postMembership)
        {
            var membership = new Membership()
            {
                MemberID = postMembership.MemberID,
                TeamID = postMembership.TeamID,
                MembershipDate = DateTime.Now
            };

            var tmp = _context.Add(membership);

            await _context.SaveChangesAsync();
           
            return membership;
        }

    }
}
