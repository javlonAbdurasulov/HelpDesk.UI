using HelpDesk.Application.Services.Interfaces;
using HelpDesk.Domain;
using HelpDesk.Domain.DTO.Letter;
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
        public async Task<Guid> Create(LetterCreateDTO letterInCreateDto)
		{

            var newLetter = Letter.CreateLetter(letterInCreateDto.Status, letterInCreateDto.Description, letterInCreateDto.Title, letterInCreateDto.ActionType);

            string? Errors = string.Join(" ", newLetter.Item2);

            if (newLetter.Item2.Count() != 0) return 0;


			await _db.Letters.AddAsync(newLetter.Item1);
			await _db.SaveChangesAsync();

            return newLetter.Item1.Id;
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
