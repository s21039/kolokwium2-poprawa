using kolokwium2_poprawa.Models;
using kolokwium2_poprawa.Models.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2_poprawa.Services
{
    public interface IDbService
    {
        public Task<Membership> AddMember(PostMembership postMembership);
    }
}
