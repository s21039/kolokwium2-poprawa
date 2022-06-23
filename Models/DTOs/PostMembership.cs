using System;

namespace kolokwium2_poprawa.Models.DTOs
{
    public class PostMembership
    {
        public int MemberID { get; set; }
        public int TeamID { get; set; }
        public DateTime MembershipDate { get; set; }
    }
}
