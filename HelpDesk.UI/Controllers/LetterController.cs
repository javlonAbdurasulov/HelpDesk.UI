using HelpDesk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[aciton]")]
    public class LetterController : ControllerBase
    {
        public ILetterService _letterService;
        public LetterController(ILetterService letterService)
        {
            _letterService=letterService;
        }

        
     
    }
}
