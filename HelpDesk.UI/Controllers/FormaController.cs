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
            var FormaResponseModel = await _formService.Create(formInCreateDto);
            return FormaResponseModel;
        }
        [HttpDelete]
        public async Task<bool> DeleteForm(int Id)
        {
            var DeleteFormaResponseModel = await _formService.Delete(Id);
            return DeleteFormaResponseModel;
        }
        [HttpPut]
        public async Task<bool> UpdateForm(Forma forma)
        {
            var UpdateFormaResponseModel = await _formService.Update(forma);
            return UpdateFormaResponseModel;
        }
        [HttpPost]
        public async Task<ResponseModel<Forma>> GetByIdForm(int Id)
        {
            var FormaResponseModel = await _formService.GetById(Id);
            return FormaResponseModel;
        }
    }
}
