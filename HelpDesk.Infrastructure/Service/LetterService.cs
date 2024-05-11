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
	public class LetterService : ILetterService
	{
		public IFormService FormService;
		public AppDbContext _db;
        public LetterService(IFormService formService,AppDbContext db)
        {
			_db = db;
            FormService =formService;
        }
        public async Task<int> Create(Letter obj)
		{
		int formId = await FormService.Create(obj.Forma);

			await _db.Letters.AddAsync(obj);
			await _db.SaveChangesAsync();

            return obj.Id;

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
