using HelpDesk.Application.Services.Interfaces;
using HelpDesk.Domain;
using HelpDesk.Domain.DTO.Letter;
using HelpDesk.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

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
        public async Task<ResponseModel<Letter>> CreateLetter(LetterCreateDTO letterInCreateDto)
        {

               var id = await _letterService.Create(letterInCreateDto);

            return new ResponseModel<Letter>(newLetter.Item1);
        }
        
     
    }
}
