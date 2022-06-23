using System;
using System.Collections.Generic;

namespace kolokwium2_poprawa.Models.DTOs
{
    public class GetTeam
    {
        public string TeamName { get; set; }
        public DateTime MembershipDate { get; set; }
        public ICollection<GetMembers> Members { get; set; }
    }
}
