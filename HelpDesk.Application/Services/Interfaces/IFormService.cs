﻿using HelpDesk.Domain.DTO.Forma;
using HelpDesk.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Application.Services.Interfaces
{
	public interface IFormService:
		ICreateService<FormaCreateDTO>,
		IUpdateService<Forma>,
		IGetByIdService<Forma>
	{

	}
}
