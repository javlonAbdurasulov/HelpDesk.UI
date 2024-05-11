using HelpDesk.Application.Services.Interfaces;
using HelpDesk.Domain;
using HelpDesk.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LetterController : ControllerBase
    {
        public ILetterService _letterService;
        public LetterController(ILetterService letterService)
        {
            _letterService=letterService;
        }

        [HttpPost]
        public async Task<ResponseModel<Letter>> CreateLetter(Letter letter)
        {
            await _letterService.Create(letter);
            return new ResponseModel<Letter>(letter);
        }
        
     
    }
}
