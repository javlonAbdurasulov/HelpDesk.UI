using HelpDesk.Application.Services.Interfaces;
using HelpDesk.Domain;
using HelpDesk.Domain.DTO.Forma;
using HelpDesk.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FormaController : ControllerBase
    {
        public IFormService _formService;
        public FormaController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpPost]
        public async Task<ResponseModel<Forma>> CreateForm(FormaCreateDTO formInCreateDto)
        {
            var letterResponseModel = await _formService.Create(formInCreateDto);
            return letterResponseModel;
        }
    }
}
