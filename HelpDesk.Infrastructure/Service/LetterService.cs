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
		public AppDbContext _db;
        public LetterService(AppDbContext db)
        {
			_db = db;
        }
        public async Task<ResponseModel<Letter>> Create(LetterCreateDTO letterInCreateDto)
		{

            var newLetter = Letter.CreateLetter(letterInCreateDto.Status, letterInCreateDto.Description, letterInCreateDto.Title, letterInCreateDto.ActionType);

            string? Errors = string.Join(" ", newLetter.Item2);

            if (newLetter.Item2.Count() != 0) return new ResponseModel<Letter>(Errors, System.Net.HttpStatusCode.Conflict);


			await _db.Letters.AddAsync(newLetter.Item1);
			await _db.SaveChangesAsync();

            return new ResponseModel<Letter>(newLetter.Item1);
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
