using HelpDesk.Application.Services.Interfaces;
using HelpDesk.Domain.Entity;
using HelpDesk.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Infrastructure.Service
{
	public class FormService : IFormService
	{
		public AppDbContext _db;
        public FormService(AppDbContext Context)
        {
            _db = Context;
        }
        public async Task<int> Create(Forma obj)
		{
            await _db.Formas.AddAsync(obj);
            await _db.SaveChangesAsync();

            return obj.Id;


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
