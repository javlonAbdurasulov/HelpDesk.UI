using HelpDesk.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Application.Services.Interfaces
{
	public interface IGetByIdService<T>
	{
		public Task<ResponseModel<T>> GetById(int Id);
	}
}
