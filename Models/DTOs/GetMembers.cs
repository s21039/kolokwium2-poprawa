using System;

namespace kolokwium2_poprawa.Models.DTOs
{
    public class GetMembers
    {
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public DateTime MembershipDate { get; set; }
    }
}
