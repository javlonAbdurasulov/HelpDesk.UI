using HelpDesk.Domain;
using HelpDesk.Domain.DTO.Letter;
using HelpDesk.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Application.Services.Interfaces
{
	public interface ILetterService:
		IUpdateService<Letter>,
		IGetAllService<Letter>,
		IGetByIdService<Letter>,
		IDeleteService
	{
		public Task<ResponseModel<Letter>> Create(LetterCreateDTO letterCreateDTO);
    }
}
