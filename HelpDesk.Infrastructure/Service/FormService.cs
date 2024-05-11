using HelpDesk.Application.Services.Interfaces;
using HelpDesk.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Infrastructure.Service
{
	public class FormService : IFormService
	{
		public Task<bool> Create(Forma obj)
		{
			throw new NotImplementedException();
		}

		public Task<Forma> GetById(int Id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(Forma obj)
		{
			throw new NotImplementedException();
		}
	}
}
