using kolokwium2_poprawa.Models.DTOs;
using kolokwium2_poprawa.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace kolokwium2_poprawa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IDbService _service;

        public MemberController(IDbService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddMember(PostMembership postMembership)
        {
            await _service.AddMember(postMembership);
            return Ok("Member added");
        }
    }
}
