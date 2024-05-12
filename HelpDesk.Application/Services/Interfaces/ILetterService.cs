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
		ICreateService<LetterCreateDTO>,
		IUpdateService<Letter>,
		IGetAllService<Letter>,
		IGetByIdService<Letter>,
		IDeleteService
	{	}
}
