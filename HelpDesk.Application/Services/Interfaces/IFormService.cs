using HelpDesk.Domain;
using HelpDesk.Domain.DTO.Forma;
using HelpDesk.Domain.DTO.Letter;
using HelpDesk.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Application.Services.Interfaces
{
	public interface IFormService:
		IUpdateService<Forma>,
		IGetByIdService<Forma>,
		IDeleteService
	{
        public Task<ResponseModel<Forma>> Create(FormaCreateDTO formCreateDTO);
    }
}
