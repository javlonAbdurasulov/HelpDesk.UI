using HelpDesk.Application.Services.Interfaces;
using HelpDesk.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Infrastructure.Service
{
	public class LetterService : ILetterService
	{
		public Task<bool> Create(Letter obj)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(int Id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Letter>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<Letter> GetById(int Id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(Letter obj)
		{
			throw new NotImplementedException();
		}
	}
}
